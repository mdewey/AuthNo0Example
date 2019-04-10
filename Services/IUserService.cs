using System.Threading.Tasks;
using AuthNo0Example.Models;

namespace AuthNo0Example.Services
{
  public interface IUserService
  {
    Task<User> GetUserFromDatabaseAsync(System.Security.Claims.ClaimsPrincipal user);
  }
}