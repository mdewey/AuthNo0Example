namespace AuthNo0Example.ViewModels
{
  public class AuthData
  {
    public string Token { get; set; }
    public long TokenExpirationTime { get; set; }
    public int Id { get; set; }
    public UserViewModel User { get; set; }
  }
}