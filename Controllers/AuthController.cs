using System;
using System.Linq;
using System.Threading.Tasks;
using AuthNo0Example.Models;
using AuthNo0Example.Services;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace content.Controllers
{
  [Route("auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    IAuthService authService;
    DatabaseContext db;
    public AuthController(IAuthService authService, DatabaseContext db)
    {
      this.db = db;
      this.authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<Object>> Post([FromBody]LoginViewModel model)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var user = await this.db.Users.FirstOrDefaultAsync(f => f.UserName == model.UserName);

      if (user == null)
      {
        return BadRequest(new { email = "no user with this email" });
      }

      var passwordValid = authService.VerifyPassword(user, model.Password);
      if (!passwordValid)
      {
        return BadRequest(new { password = "invalid password" });
      }
      user.LastLoggedIn = DateTime.Now;
      await this.db.SaveChangesAsync();
      return authService.GetAuthData(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<object>> Post([FromBody]SignUp model)
    {
      if (!ModelState.IsValid) return BadRequest(ModelState);

      var alreadyExists = await this.db.Users.AnyAsync(a => a.UserName == model.UserName);
      if (alreadyExists) return BadRequest(new { username = "user with this email already exists" });

      var user = new User
      {
        UserName = model.UserName,
        FullName = model.FullName
      };
      user.Password = authService.HashPassword(user, model);
      this.db.Users.Add(user);
      await this.db.SaveChangesAsync();

      return authService.GetAuthData(user);
    }

  }
}