using System;
using System.Threading.Tasks;
using System.Web;
using AntDesign;
using Athena.Blog.CMS.Helpers;
using Athena.Blog.CMS.Models;
using Athena.Blog.CMS.Services;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.User.Login;

public partial class Login
{
    private readonly LoginParamsType _model = new LoginParamsType();

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public MessageService Message { get; set; }

    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    public bool ShowAuthError { get; set; }

    public string Error { get; set; }

    public async Task HandleSubmit()
    {
        ShowAuthError = false;

        try
        {
            var response = await AuthenticationService.Authenticate(new AuthRequestDto
            {
                Email = _model.Email,
                Password = _model.Password
            });

            if (response.IsAuthenticated)
            {
                // Check if returnUrl is has value
                var returnUrl = NavigationManager.QueryString("returnUrl");
                NavigationManager.NavigateTo(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "/");
            }
        }
        catch (ApiException e)
        {
            Message.Error(e.Detail);
        }
    }
}