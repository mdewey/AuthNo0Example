using System.Threading.Tasks;
using AuthNo0Example.Models;

namespace AuthNo0Example.Services
{
  public interface IUserService
  {
    Task<User> GetUserFromDatabase(System.Security.Claims.ClaimsPrincipal user);
  }
}