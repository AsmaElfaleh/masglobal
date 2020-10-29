import React, { Component } from 'react';
import { Container } from 'reactstrap';
import EmployeeList from './EmployeeList';
import EmployeeForm from './EmployeeForm';
import logo from '../LogoMasGlobalHeader.png';
import axios from 'axios';

class EmployeeContainer extends Component {
    constructor(props) {
        super(props);
        this.state = { data: [], employeeId: '', showComponent: false };
        this.handleEmployIdSubmit = this.handleEmployIdSubmit.bind(this);
        this.EmployeeList = null;
    }
    handleEmployIdSubmit(employee) {
        this.setState({ employeeId: employee.id, showComponent: false })
        this.getEmployees(employee.id);
        this.EmployeeList = <EmployeeList data={this.state.data} />;
        this.forceUpdate();
    }
    getEmployees(employeeId){
        var apiUrl = process.env.REACT_APP_EMPLOYEES_API_URL
        if (employeeId) {
            apiUrl = apiUrl + "/" + employeeId
            axios.get(apiUrl)
                .then(response => {
                    const data = this.state.data;
                    data.push(response.data);
                    this.setState({ data: data,  showComponent: true });
                })
                .catch(function (error) {
                    console.log(error);
                })
        } else {
            axios.get(apiUrl)
                .then(response => {
                    this.setState({ data: response.data,  showComponent: true });
                })
                .catch(function (error) {
                    console.log(error);
                })
        }
    }

    render() {
        return [
            <div className="EmployeeContainer">
                <img src={logo} className='App-logo' />
                <Container>
                    <React.Fragment>
                        <EmployeeForm onActionSubmit={this.handleEmployIdSubmit} />
                        {this.state.showComponent ?
                            this.EmployeeList: null
                        }
                    </React.Fragment>
                </Container>
            </div>
        ];
    }
}

export default EmployeeContainer;
