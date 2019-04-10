using System.Threading.Tasks;
using AuthNo0Example.Models;
using content;
using Microsoft.EntityFrameworkCore;

namespace AuthNo0Example.Services
{
  public class UserService : IUserService
  {
    private readonly DatabaseContext db;

    public UserService(DatabaseContext db)
    {
      this.db = db;
    }

    public async Task<User> GetUserFromDatabaseAsync(System.Security.Claims.ClaimsPrincipal user)
    {
      var userName = user?.Identity?.Name;
      var currentUser = await this.db.Users.FirstOrDefaultAsync(f => f.UserName == userName);
      currentUser.Password = null;
      return currentUser;
    }
  }
}