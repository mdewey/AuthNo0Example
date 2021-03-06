using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthNo0Example.Models;
using AuthNo0Example.Services;
using AuthNo0Example.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace content.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class WhoController : ControllerBase
  {
    private readonly IUserService userService;

    public WhoController(IUserService userService)
    {
      this.userService = userService;
    }
    [HttpGet]
    public async Task<ActionResult<UserViewModel>> GetUserProfile()
    {
      var rv = await this.userService.GetUserFromDatabaseAsync(User);
      return new UserViewModel(rv);
    }
  }
}