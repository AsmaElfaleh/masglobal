import React, { Component } from 'react';
import Table from './Table';
import './Table.css';
export default class EmployeeList extends Component {
    constructor(props) {
        super(props);
        this.state = { data: [], employeeId: '' }
    }
    tabRow() {
        return this.props.data.map(function (object, i) {
            return <Table obj={object} key={i} />;
        });
    }
    render() {
        return (
            <div>
                <h2 align="center" id='title'>Employees List</h2>
                <table id='employees'>
                    <thead className="thead-light">
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