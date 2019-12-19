import React, { Component } from 'react';
import './App.css';
import { Button, Card, CardBody, CardGroup, Col, Container, Form, Input, InputGroup, InputGroupAddon, InputGroupText, Row } from 'reactstrap';
class StudentDashboard extends Component {
    render() {

        return (
            <div className="row" className="mb-2 pageheading">
                <div className="col-sm-12 btn btn-primary">
                    <h1>Student Dashboard</h1>
             </div>
            </div>
        );
    }
}

export default StudentDashboard;  