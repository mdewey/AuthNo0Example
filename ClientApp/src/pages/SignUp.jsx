import React, { Component } from 'react'

import axios from 'axios'

import Auth from '../Auth'

class SignUp extends Component {
  handleChange = e => {
    this.setState({
      [e.target.name]: e.target.value
    })
  }

  onSubmit = e => {
    e.preventDefault()
    axios
      .post('/auth/register', {
        userName: this.state.email,
        fullName: this.state.fullName,
        password: this.state.password
      })
      .then(resp => {
        new Auth(this.props.history).setSession(resp.data)
      })
  }
  render() {
    return (
      <div>
        <h1 className="display-4">Sign up to become a FooBar!</h1>
        <form onSubmit={this.onSubmit}>
          <div className="form-group">
            <label for="fullNameExample">Full Name</label>
            <input
              onChange={this.handleChange}
              type="text"
              name="fullName"
              className="form-control"
              id="fullNameExample"
              aria-describedby="nameHelp"
              placeholder="Full Name"
            />
            <small id="nameHelp" className="form-text text-muted">
              First and last name please.
            </small>
          </div>
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
              We'll never share your email with anyone else.
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
