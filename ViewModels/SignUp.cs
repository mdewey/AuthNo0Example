using System.ComponentModel.DataAnnotations;

namespace AuthNo0Example.ViewModels
{
  public class SignUp
  {
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
    public string FullName { get; set; }
  }
}