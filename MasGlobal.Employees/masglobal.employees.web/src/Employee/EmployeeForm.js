import React, { Component } from 'react';
import { Button } from "react-bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

class EmployeeForm extends Component {
    constructor(props) {
        super(props);
        this.state = { id: '' };
        this.handleIdChange = this.handleIdChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleIdChange(e) {
        this.setState({ id: e.target.value });
    }
    handleSubmit(e) {
        e.preventDefault();
        const id = this.state.id
        this.props.onActionSubmit({ id: id });
        this.setState({ id: '' });
    }
    render() {
        return (
            <form className="EmployeeForm" onSubmit={this.handleSubmit}>
                <input
                    type="number"
                    pattern="[0-9]*"
                    inputMode="numeric"
                    placeholder="Employee Id"
                    value={this.state.id}
                    onChange={this.handleIdChange}
                />
                <input type="submit" value="Get Employees" variant="primary" />
            </form>
        );
    }
}

export default EmployeeForm;