using System.Threading.Tasks;
using AntDesign;
using Athena.Blog.CMS.Models;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.User.Login;

public partial class Login
{
    private readonly LoginParamsType _model = new LoginParamsType();

    [Inject] public NavigationManager NavigationManager { get; set; }
    
    [Inject] public MessageService Message { get; set; }

    public void HandleSubmit() {
        if (_model.UserName == "admin" && _model.Password == "ant.design") {
            NavigationManager.NavigateTo("/");
            return;
        }

        if (_model.UserName == "user" && _model.Password == "ant.design") NavigationManager.NavigateTo("/");
    }
}