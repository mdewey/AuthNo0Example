import React from 'react'
import Auth from '../Auth'

export default function Logout(props) {
  new Auth(props.history).logout()
  return <>logging you out...</>
}
