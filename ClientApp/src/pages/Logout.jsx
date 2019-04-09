import React from 'react'
import Auth from '../Auth'
import { Redirect } from 'react-router-dom'

export default function Logout(props) {
  new Auth(props.history).logout()
  return <>logging you out...</>
}
