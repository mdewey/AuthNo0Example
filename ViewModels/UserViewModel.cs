using System;
using AuthNo0Example.Models;

namespace AuthNo0Example.ViewModels
{
  public class UserViewModel
  {
    public int Id { get; set; }
    public string UserName { get; set; }

    public string FullName { get; set; }

    public DateTime? DateCreated { get; set; } = DateTime.Now;

    public DateTime LastLoggedIn { get; set; } = DateTime.Now;
    public UserViewModel() { }
    public UserViewModel(User user)
    {
      this.Id = user.Id;
      this.UserName = user.UserName;
      this.FullName = user.FullName;
      this.DateCreated = user.DateCreated;
      this.LastLoggedIn = user.LastLoggedIn;
    }
  }
}