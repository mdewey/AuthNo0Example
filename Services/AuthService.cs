using AuthNo0Example.Models;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthNo0Example.Services
{
  public class AuthService : IAuthService
  {
    public AuthData GetAuthData(User user)
    {
      throw new System.NotImplementedException();
    }

    public string HashPassword(User user, SignUp data)
    {
      return new PasswordHasher<User>().HashPassword(user, data.Password);
    }

    public bool VerifyPassword(User user, string providedPassword)
    {
      return new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, providedPassword) == PasswordVerificationResult.Success;
    }
  }
}