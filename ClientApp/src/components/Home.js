import React, { Component } from 'react'

export class Home extends Component {
  static displayName = Home.name

  render() {
    return (
      <div>
        <h1>Welcome to the Foobars</h1>
        <img src="https://placebear.com/200/300" />
      </div>
    )
  }
}
