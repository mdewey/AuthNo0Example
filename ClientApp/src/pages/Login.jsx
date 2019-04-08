import React, { Component } from 'react'
import axios from 'axios'

class SignUp extends Component {
  state = {}
  handleChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    })
  }

  onSubmit = e => {
    e.preventDefault()
    axios
      .post('/auth/login', {
        userName: this.state.email,
        password: this.state.password
      })
      .then(resp => {
        console.log({ resp })
        if (resp.data.token) {
          localStorage.setItem('auth-data', JSON.stringify(resp.data))
          this.props.history.push('/')
        } else {
          this.setState({
            message: 'Try again'
          })
        }
      })
      .catch(err => {
        this.setState({
          message: 'Try again'
        })
      })
  }
  render() {
    return (
      <div>
        <h1 className="display-4">Log in to see what you saw!</h1>
        {this.state.message && (
          <div class="alert alert-warning" role="alert">
            {this.state.message}
          </div>
        )}
        <form onSubmit={this.onSubmit}>
          <div className="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <input
              onChange={this.handleChange}
              type="email"
              name="email"
              className="form-control"
              id="exampleInputEmail1"
              aria-describedby="emailHelp"
              placeholder="Enter email"
            />
            <small id="emailHelp" className="form-text text-muted">
              Welcome Back
            </small>
          </div>
          <div className="form-group">
            <label for="exampleInputPassword1">Password</label>
            <input
              onChange={this.handleChange}
              type="password"
              name="password"
              className="form-control"
              id="exampleInputPassword1"
              placeholder="Password"
            />
          </div>
          <button type="submit" className="btn btn-primary">
            Submit
          </button>
        </form>
      </div>
    )
  }
}

export default SignUp
