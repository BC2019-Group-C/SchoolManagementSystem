import React, { Component } from 'react';

export class Student extends Component {
  static displayName = Student.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static renderStudentTable(studentTable) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Id</th>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Gender</th>
            <th>Date Of Birth</th>
                    <th>Conttact Number</th>
                    <th>Class</th>
          </tr>
        </thead>
        <tbody>
          {studentTable.map(studentTable =>
            <tr key={studentTable.className}>
              <td>{studentTable.id}</td>
              <td>{studentTable.firstName}</td>
              <td>{studentTable.lastName}</td>
                  <td>{studentTable.gender}</td>
                  <td>{studentTable.dateOfBirth}</td>
                  <td>{studentTable.contactNumber}</td>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
          : Student.renderForecastsTable(this.state.forecasts);
      

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}
