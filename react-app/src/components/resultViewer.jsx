import React, { Component } from "react";

class ResultViewer extends Component {
  renderResult() {
    if (this.props.result.tries === 0) {
      return null;
    }
    return (
      <div className={this.getResultClass()} role="alert">
        <h4 className="alert-heading">{this.getResultHeading()}</h4>
        <p>{this.getResultText()}</p>
        <p>Number of cars: {this.props.result.wins}</p>
      </div>
    );
  }

  getResultClass() {
    let classes = "alert alert-";
    classes += this.isSuccess() ? "success" : "warning ";
    return classes;
  }

  getResultHeading() {
    return this.isSuccess() ? "Success!" : "Oh, darn it!";
  }

  getResultText() {
    return this.isSuccess()
      ? "The car was one more than half of the times."
      : "You would get the goat more times than not.";
  }

  isSuccess() {
    return this.props.result.wins / this.props.result.tries > 0.5;
  }

  render() {
    return <React.Fragment>{this.renderResult()}</React.Fragment>;
  }
}

export default ResultViewer;
