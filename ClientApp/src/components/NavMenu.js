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

export class NavMenu extends Component {
  static displayName = NavMenu.name

  constructor(props) {
    super(props)

    this.toggleNavbar = this.toggleNavbar.bind(this)
    this.state = {
      collapsed: true
    }
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed
    })
  }

  componentWillReceiveProps(p, n) {
    console.log({ p, n })
  }
  getAuthMenu = () => {
    if (new Auth().isAuthenticated()) {
      return (
        <>
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
              content
            </NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <ul className="navbar-nav flex-grow">
                <NavItem>
                  <NavLink tag={Link} className="text-dark" to="/">
                    Home
                  </NavLink>
                </NavItem>
                {this.getAuthMenu()}
              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    )
  }
}
