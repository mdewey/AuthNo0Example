using System.ComponentModel.DataAnnotations;

namespace AuthNo0Example.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
  }
}