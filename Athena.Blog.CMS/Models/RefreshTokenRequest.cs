using Athena.Shared.DTOs.Authentication;

namespace Athena.Blog.CMS.Models;

public class RefreshTokenRequest : IRefreshTokenRequest
{
    public string RefreshToken { get; set; }
    
    public string AccessToken { get; set; }
}