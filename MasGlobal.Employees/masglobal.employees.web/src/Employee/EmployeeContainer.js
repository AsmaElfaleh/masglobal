import React, { Component } from 'react';
import { Container } from 'reactstrap';
import EmployeeList from './EmployeeList';
import EmployeeForm from './EmployeeForm';
import logo from '../LogoMasGlobalHeader.png'

class EmployeeContainer extends Component {
    constructor(props) {
        super(props);
        this.state = { employeeId: '', showComponent: false };
        this.handleEmployIdSubmit = this.handleEmployIdSubmit.bind(this);
        this.EmployeeList = null;
    }
    handleEmployIdSubmit(employee) {
        this.setState({ employeeId: employee.id, showComponent: true })
        this.EmployeeList = <EmployeeList employeeId={employee.id} />;
        this.forceUpdate();
    }

    render() {
        return [
            <div className="EmployeeContainer">
                <img src={logo} className='App-logo' />
                <Container>
                    <React.Fragment>
                        <EmployeeForm onActionSubmit={this.handleEmployIdSubmit} />
                        {this.state.showComponent ?
                            this.EmployeeList : null
                        }
                    </React.Fragment>
                </Container>
            </div>
        ];
    }
}

export default EmployeeContainer;
