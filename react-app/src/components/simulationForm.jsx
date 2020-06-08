import React, { Component } from "react";
import axios from "axios";

class SimulationForm extends Component {
  state = {
    numberOfSim: "",
    switchDoor: false,
  };

  handleNumberChange(event) {
    this.setState({ numberOfSim: event.target.value });
  }

  handleSwitchChange(event) {
    this.setState({ switchDoor: event.target.checked });
  }

  handleSubmit(event) {
    axios
      .get(
        "http://localhost:56645/api/gameshow/" +
          this.state.numberOfSim +
          "?switchDoor=" +
          this.state.switchDoor
      )
      .then((response) => {
        this.props.onResult({
          result: {
            tries: this.state.numberOfSim,
            wins: response.data,
          },
        });
      })
      .catch(function (error) {
        console.log(error);
        this.props.onResult({
          result: {
            tries: 0,
            wins: 0,
          },
        });
      });
    event.preventDefault();
  }

  render() {
    return (
      <div className="row">
        <div className="col-xl-5 col-lg-6 col-md-8 col-sm-10 mx-auto text-center form p-4">
          <div className="px-2">
            <form
              className="justify-content-center"
              onSubmit={(e) => this.handleSubmit(e)}
            >
              <div className="form-group">
                <label className="h5">Number of simulations</label>
                <input
                  className="form-control"
                  type="number"
                  min="1"
                  max="100000"
                  placeholder="Enter number of simulations"
                  value={this.state.numberOfSim}
                  onChange={(e) => this.handleNumberChange(e)}
                />
              </div>
              <div className="form-group">
                <input
                  className="form-check-input"
                  type="checkbox"
                  value={this.state.switchDoor}
                  onChange={(e) => this.handleSwitchChange(e)}
                />
                <label className="form-check-label h6">Switch door</label>
              </div>
              <button type="submit" className="btn btn-primary btn-lg">
                Run simulation
              </button>
            </form>
          </div>
        </div>
      </div>
    );
  }
}

export default SimulationForm;
