using System.ComponentModel.DataAnnotations;

namespace Athena.Blog.CMS.Models;

public class LoginParamsType
{
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }

    public bool AutoLogin { get; set; }
}