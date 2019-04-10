namespace AuthNo0Example.Models
{
  public class Foobar
  {
    public int Id { get; set; }
    public string Foo { get; set; }
    public double Bar { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
  }
}