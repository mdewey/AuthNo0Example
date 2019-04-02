using System;
using System.Linq;
using System.Threading.Tasks;
using AuthNo0Example.Models;
using AuthNo0Example.Services;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace content.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PingController : ControllerBase
  {
    public IUserService userService { get; }

    public PingController(IUserService userService)
    {
      this.userService = userService;
    }


    [Authorize]
    public async Task<ActionResult> Pong()
    {
      var currentUser = await this.userService.GetUserFromDatabase(User);

      return Ok(new { User.Claims, User.Identity.Name, currentUser });
    }
  }
}