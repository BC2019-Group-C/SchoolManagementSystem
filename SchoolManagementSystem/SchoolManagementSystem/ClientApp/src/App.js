import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { Student } from './components/Students';
import { StudentLogin } from './components/StudentLogin';
import Dashboard from './components/StudentDashboard'; 
import { BrowserRouter as Router, Switch, Link } from 'react-router-dom';

import './custom.css'
import './App.css';  

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
        <Route path='/counter' component={Counter} />
        <Route path='/fetch-data' component={FetchData} />
        <Route path='/admin' component={Student} />
            <Route exact path='/SMS/studentLogin' component={StudentLogin} />
            <Route exac path='/Dashboard' component={Dashboard} />
      </Layout>
    );
  }
}
