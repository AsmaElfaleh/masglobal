import React, { Component } from 'react';

class Table extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <tr class="table-active">
                <td>
                    {this.props.obj.id}
                </td>
                <td>
                    {this.props.obj.name}
                </td>
                <td>
                    {this.props.obj.contractTypeName}
                </td>
                <td>
                    {this.props.obj.roleId}
                </td>
                <td>
                    {this.props.obj.roleName}
                </td>
                <td>
                    {this.props.obj.roleDescription}
                </td>
                <td>
                    {this.props.obj.hourlySalary}
                </td>
                <td>
                    {this.props.obj.monthlySalary}
                </td>
                <td>
                    {this.props.obj.annualSalary}
                </td>
            </tr>
        );
    }
}

export default Table;  