using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthNo0Example.Models;
using AuthNo0Example.Services.Settings;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AuthNo0Example.Services
{
  public class AuthService : IAuthService
  {

    private double jwtLifespan;
    private string jwtSecret;

    public AuthService(IOptions<AuthSettings> settings)
    {
      this.jwtLifespan = settings.Value.JwtLifespan;
      this.jwtSecret = settings.Value.JwtToken;
    }

    public AuthData GetAuthData(User user)
    {
      var expirationTime = DateTime.UtcNow.AddSeconds(jwtLifespan);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Gender, "non-binary"),
            new Claim("id", user.Id.ToString())
        }),
        Expires = expirationTime,
        // new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature)
        SigningCredentials = new SigningCredentials(
              new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret)),
              SecurityAlgorithms.HmacSha256Signature
          )
      };
      var tokenHandler = new JwtSecurityTokenHandler();
      var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

      return new AuthData
      {
        Token = token,
        TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
        Id = user.Id,
        User = new UserViewModel(user)
      };
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