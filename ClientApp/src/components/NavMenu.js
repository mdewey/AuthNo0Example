import React, { Component } from 'react'
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavItem,
  NavLink
} from 'reactstrap'
import { Link } from 'react-router-dom'
import './NavMenu.css'

import Auth from '../Auth'
const auth = new Auth()
export class NavMenu extends Component {
  static displayName = NavMenu.name

  constructor(props) {
    super(props)

    this.toggleNavbar = this.toggleNavbar.bind(this)
    this.state = {
      collapsed: true,
      user: {}
    }
  }

  componentDidMount() {
    if (auth.isAuthenticated()) {
      auth.getProfile(user => {
        this.setState({
          user
        })
      })
    }
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    })
  }

  getAuthMenu = () => {
    if (auth.isAuthenticated()) {
      return (
        <>
          <NavLink tag={Link} className="text-dark" to="#">
            <NavItem>Welcome, {this.state.user.fullName}</NavItem>
          </NavLink>
          <NavItem>
            <NavLink tag={Link} className="text-dark" to="/logout">
              Log out
            </NavLink>
          </NavItem>
        </>
      )
    } else {
      return (
        <>
          <NavItem>
            <NavLink tag={Link} className="text-dark" to="/signup">
              Sign Up
            </NavLink>
          </NavItem>
          <NavItem>
            <NavLink tag={Link} className="text-dark" to="/login">
              Log in
            </NavLink>
          </NavItem>
        </>
      )
    }
  }

  render() {
    return (
      <header>
        <Navbar
          className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3"
          light
        >
          <Container>
            <NavbarBrand tag={Link} to="/">
              SDG FooBar
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">{this.getAuthMenu()}</ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    )
  }
}
