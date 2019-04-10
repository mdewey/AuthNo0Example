import React, { Component } from 'react'
import axios from 'axios'
import faker from 'faker'

import Auth from '../Auth'

const auth = new Auth()

class Foobars extends Component {
  state = {
    foobars: []
  }

  componentDidMount() {
    if (!auth.isAuthenticated()) {
      window.localtion.href = '/'
    } else {
      this.getAllFooBars()
    }
  }

  getAllFooBars = () => {
    axios
      .get('/api/foobar', {
        headers: { Authorization: auth.authorizationHeader() }
      })
      .then(resp => {
        this.setState({
          foobars: resp.data
        })
      })
  }

  createRandomData = () => {
    const data = {
      foo: faker.hacker.noun(),
      bar: faker.finance.amount()
    }

    axios
      .post('/api/foobar', data, {
        headers: { Authorization: auth.authorizationHeader() }
      })
      .then(resp => {
        this.getAllFooBars()
      })
  }

  render() {
    return (
      <>
        <header>Create yourself some foobars</header>
        <section>
          <button onClick={this.createRandomData}>
            {' '}
            Create a random Foobar
          </button>
        </section>
        <section>
          <ul>
            {this.state.foobars.map(foobar => {
              return (
                <li key={foobar.id}>
                  {foobar.foo} and {foobar.bar}
                </li>
              )
            })}
          </ul>
        </section>
      </>
    )
  }
}

export default Foobars
