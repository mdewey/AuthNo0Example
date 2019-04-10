using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AuthNo0Example.Models;
using content;
using Microsoft.AspNetCore.Authorization;
using AuthNo0Example.Services;

namespace content.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class FoobarController : ControllerBase
  {
    private IUserService _userService;
    private readonly DatabaseContext _context;

    public FoobarController(DatabaseContext context, IUserService userService)
    {
      this._userService = userService;
      _context = context;
    }

    // GET: api/Foobar
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Foobar>>> GetFoobars()
    {
      var user = await _userService.GetUserFromDatabaseAsync(User);
      return await _context.Foobars.Where(w => w.UserId == user.Id).ToListAsync();
    }

    // GET: api/Foobar/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Foobar>> GetFoobar(int id)
    {
      var user = await _userService.GetUserFromDatabaseAsync(User);
      var foobar = await _context.Foobars.FirstOrDefaultAsync(f => f.Id == id && f.UserId == user.Id);

      if (foobar == null)
      {
        return NotFound();
      }

      return foobar;
    }

    // PUT: api/Foobar/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFoobar(int id, Foobar foobar)
    {
      var user = await _userService.GetUserFromDatabaseAsync(User);
      _context.Entry(user).State = EntityState.Deleted;
      if (id != foobar.Id || foobar.UserId != foobar.UserId)
      {
        return BadRequest();
      }

      _context.Entry(foobar).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!FoobarExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Foobar
    [HttpPost]
    public async Task<ActionResult<Foobar>> PostFoobar(Foobar foobar)
    {
      var user = await _userService.GetUserFromDatabaseAsync(User);
      foobar.UserId = user.Id;

      _context.Foobars.Add(foobar);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetFoobar", new { id = foobar.Id }, foobar);
    }

    // DELETE: api/Foobar/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Foobar>> DeleteFoobar(int id)
    {
      var foobar = await _context.Foobars.FindAsync(id);
      var user = await _userService.GetUserFromDatabaseAsync(User);

      if (foobar == null || foobar.UserId != user.Id)
      {
        return NotFound();
      }

      _context.Foobars.Remove(foobar);
      await _context.SaveChangesAsync();

      return foobar;
    }

    private bool FoobarExists(int id)
    {
      return _context.Foobars.Any(e => e.Id == id);
    }
  }
}
