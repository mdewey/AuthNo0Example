using System;
using System.Linq;
using System.Threading.Tasks;
using AuthNo0Example.Models;
using AuthNo0Example.Services;
using AuthNo0Example.Services.Settings;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace content.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PingController : ControllerBase
  {
    public IUserService userService { get; }
    public IOptions<AuthSettings> authSettings { get; }

    public PingController(IUserService userService, IOptions<AuthSettings> authSettings)
    {
      this.userService = userService;
      this.authSettings = authSettings;
    }


    [Authorize]
    [HttpGet]
    public async Task<ActionResult<object>> Pong()
    {
      var currentUser = await this.userService.GetUserFromDatabase(User);

      return Ok(new { User.Claims, User.Identity.Name, currentUser });
    }
  }
}