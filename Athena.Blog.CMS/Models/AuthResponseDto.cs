namespace Athena.Blog.CMS.Models;

public class AuthResponseDto
{
    public bool IsAuthenticated { get; set; }
    
    public string AccessToken { get; set; }
    
    public string RefreshToken { get; set; }
}