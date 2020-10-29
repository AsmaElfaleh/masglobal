import React from 'react';
import EmployeeContainer from './Employee/EmployeeContainer'
import { BrowserRouter as Router } from 'react-router-dom';
import './App.css';

function App() {
    return (
        <Router>
            <div className="container" >
                <EmployeeContainer />
    
            </div>
        </Router>
    );
}

export default App;
