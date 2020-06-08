import React, { Component } from "react";
import SimulationForm from "./simulationForm";
import ResultViewer from "./resultViewer";

class Header extends Component {
  state = {
    result: {
      tries: 0,
      wins: 0,
    },
  };

  render() {
    return (
      <React.Fragment>
        <nav className="navbar navbar-light bg-light">
          <span className="navbar-brand mb-0 h1">
            Game show simulator - Car or goat?
          </span>
        </nav>
        <div className="container">
          <SimulationForm onResult={this.handleResult} />
          <ResultViewer result={this.state.result} />
        </div>
      </React.Fragment>
    );
  }

  handleResult = (result) => {
    this.setState({ result: result.result });
  };
}

export default Header;
