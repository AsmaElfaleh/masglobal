import React, { Component } from 'react';
import axios from 'axios';
import Table from './Table';
import './Table.css';
export default class EmployeeList extends Component {
    constructor(props) {
        super(props);
        this.state = { data: [], employeeId: '' }
    }
    componentDidMount() {
        debugger;
        var apiUrl = 'https://localhost:44301/Employees'
        this.setState({ employeeId: this.props.employeeId });
        if (this.props.employeeId) {
            apiUrl = apiUrl + "/" + this.props.employeeId
            axios.get(apiUrl)
                .then(response => {
                    const data = this.state.data;
                    data.push(response.data);
                    this.setState({ data: data });
                })
                .catch(function (error) {
                    console.log(error);
                })
        } else {
            axios.get(apiUrl)
                .then(response => {
                    this.setState({ data: response.data });
                })
                .catch(function (error) {
                    console.log(error);
                })
        }
    }
    tabRow() {
        return this.state.data.map(function (object, i) {
            return <Table obj={object} key={i} />;
        });
    }
    render() {
        return (
            <div>
                <h2 align="center" id='title'>Employees List</h2>
                <table id='employees'>
                    <thead class="thead-light">
                        <tr>
                            <th scope="col"> Id </th>
                            <th scope="col"> Name </th>
                            <th scope="col"> Contract Type Name </th>
                            <th scope="col"> Role Id </th>
                            <th scope="col"> Role Name </th>
                            <th> Role Description </th>
                            <th> Hourly Salary</th>
                            <th> Monthly Salary</th>
                            <th> Annual Salary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.tabRow()}
                    </tbody>
                </table>
            </div>
        );
    }
}  