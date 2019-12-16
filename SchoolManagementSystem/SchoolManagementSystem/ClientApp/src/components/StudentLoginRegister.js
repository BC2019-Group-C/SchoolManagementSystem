import React, { Component } from 'react';
import { Button, Card, CardFooter, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';

export class StudentLoginRegister extends Component {

    constructor() {
        super();

        this.state = {
            Id: '',
            UserName: '',
            Password: '',
            StudentUser: '',
            StudentId: ''
        }

        this.Id = this.Id.bind(this);
        this.UserName = this.UserName.bind(this);
        this.Password = this.Password.bind(this);
        this.StudentUser = this.StudentUser.bind(this);
        this.StudentId = this.StudentId.bind(this);
    }

    Id(event) {
        this.setState({ Id: event.target.value })
    }

    UserName(event) {
        this.setState({ UserName: event.target.value })
    }

    Password(event) {
        this.setState({ Password: event.target.value })
    }

    StudentUser(event) {
        this.setState({ StudentUser: event.target.value })
    }

    StudentId(event) {
        this.setState({ StudentId: event.target.value })
    }

    register(event) {

        fetch('http://localhost:44307/SMS/StudentLogin/SignUp', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({

                UserName : this.state.UserName,
                Password : this.state.Password,
                StudentUser : null,
                StudentId : this.state.StudentId
            })
        }).then((LoginResponse) => Response.json())
            .then((Result) => {
                if (Result.Status == 'Success')
                    this.props.history.push("/Dashboard");
                else
                    alert('Signing Up Failed')
            })
    }

    render() {

        return (
            <div className="app flex-row align-items-center">
                <Container>
                    <Row className="justify-content-center">
                        <Col md="9" lg="7" xl="6">
                            <Card className="mx-4">
                                <CardBody className="p-4">
                                    <Form>
                                        <div class="row" className="mb-2 pageheading">
                                            <div class="col-sm-12 btn btn-primary">
                                                Sign Up
                                            </div>
                                        </div>
                                        <InputGroup className="mb-3">
                                            <Input type="text" onChange={this.UserName} placeholder="Enter User Name" />
                                        </InputGroup>
                                        <InputGroup className="mb-3">
                                            <Input type="password" onChange={this.Password} placeholder="Enter Password" />
                                        </InputGroup>
                                        <InputGroup className="mb-4">
                                            <Input type="text" onChange={this.StudentId} placeholder="Enter Student Id" />
                                        </InputGroup>
                                        <Button onClick={this.register} color="success" block>Create Account</Button>
                                    </Form>
                                </CardBody>
                            </Card>
                        </Col>
                    </Row>
                </Container>
            </div>
        );
    }
}
 