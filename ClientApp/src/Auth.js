export default class Auth {
  constructor(history) {
    this.history = history
  }
  // tested

  setSession(authResult) {
    // Set the time that the Access Token will expire at
    let expiresAt = JSON.stringify(
      authResult.tokenExpirationTime * 1000 + new Date().getTime()
    )
    localStorage.setItem('token', JSON.stringify(authResult))
    localStorage.setItem('expires_at', expiresAt)
    this.history.push('/')
  }
  // not tested

  logout() {
    // Clear Access Token and ID Token from local storage
    localStorage.removeItem('token')
    // navigate to the home route
    this.history.push('/')
  }

  handleAuthentication(callback) {}

  isAuthenticated() {
    // Check whether the current time is past the
    // Access Token's expiry time
    let expiresAt = JSON.parse(localStorage.getItem('expires_at'))
    return new Date().getTime() < expiresAt
  }

  getToken() {
    const token = JSON.parse(localStorage.getItem('token'))
    if (!token) {
      throw new Error('No ID Token found')
    }
    return token.token
  }

  //...
  getProfile(cb) {}

  authorizationHeader() {
    return `Bearer ${this.getToken()}`
  }
}
