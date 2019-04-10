using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AuthNo0Example.Models
{
  public class User
  {
    public int Id { get; set; }
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    public string FullName { get; set; }

    public DateTime? DateCreated { get; set; } = DateTime.Now;

    public DateTime LastLoggedIn { get; set; } = DateTime.Now;

    public IList<Foobar> Foobars { get; set; } = new List<Foobar>();

  }
}