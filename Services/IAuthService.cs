using AuthNo0Example.Models;
using AuthNo0Example.ViewModels;

namespace AuthNo0Example.Services
{
  public interface IAuthService
  {
    AuthData GetAuthData(User user);
    string HashPassword(User user, SignUp data);
    bool VerifyPassword(User user, string providedPassword);
  }
}