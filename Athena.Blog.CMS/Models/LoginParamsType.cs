using System.ComponentModel.DataAnnotations;

namespace Athena.Blog.CMS.Models;

public class LoginParamsType
{
    [Required] public string UserName { get; set; }

    [Required] public string Password { get; set; }

    public bool AutoLogin { get; set; }
}