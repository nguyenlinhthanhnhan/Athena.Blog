using System.Threading.Tasks;
using Athena.Blog.CMS.Models;

namespace Athena.Blog.CMS.Services;

public interface IAuthenticationService
{
    Task<AuthResponseDto> Authenticate(AuthRequestDto request);
}