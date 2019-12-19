import React, { Component } from 'react';

import { Button, Card, CardFooter, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';

export class StudentLogin extends Component {

    constructor() {
        super();

        this.state = {
            UserName: '',
            Password: ''
        }

        this.UserName = this.UserName.bind(this);
        this.Password = this.Password.bind(this);
        this.login = this.login.bind(this);
 
    }

    UserName(event) {
        this.setState({ UserName: event.target.value })
        console.log(event.target.value)
    }

    Password(event) {
        this.setState({ Password: event.target.value })
    }

    login(event) {

        fetch('https://localhost:44307/SMS/studentLogin/Login', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({

                userName : this.state.UserName,
                password : this.state.Password
                
            })
        }).then((LoginResponse) => LoginResponse.json())
            .then((result) => {
                console.log(result);
                if (result.status === 'Success') {
                    this.props.history.push("/Dashboard");
                }
                else if (result.status === 'Invalid')
                {
                    alert(result.message);
                }
                    
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
                                        
                                        <InputGroup className="mb-3">
                                            <Input type="text" onChange={(e)=> this.UserName(e)} placeholder="Enter User Name" />
                                        </InputGroup>
                                        <InputGroup className="mb-3">
                                            <Input type="password" onChange={this.Password} placeholder="Enter Password" />
                                        </InputGroup>
                                        
                                        <Button onClick={this.login} color="success" block>Login</Button>
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

 