using System.Threading.Tasks;
using AntDesign;
using Athena.Blog.CMS.Helpers;
using Athena.Blog.CMS.Models;
using Athena.Blog.CMS.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.User.Login;

public partial class Login
{
    private readonly LoginParamsType _model = new LoginParamsType();

    [Inject] public NavigationManager NavigationManager { get; set; }

    [Inject] public MessageService Message { get; set; }

    [Inject] public IAuthenticationService AuthenticationService { get; set; }

    [Inject] public ILocalStorageService LocalStorage { get; set; }

    protected override async Task OnInitializedAsync()
    {
        // Redirect to home page if already logged in
        var token = await LocalStorage.GetItemAsync<string>("accessToken");

        if (!string.IsNullOrWhiteSpace(token))
        {
            NavigationManager.NavigateTo("/dashboard");
        }
    }

    public async Task HandleSubmit()
    {
        try
        {
            var response = await AuthenticationService.Authenticate(new AuthRequestDto
            {
                Email = _model.Email,
                Password = _model.Password
            });

            if (response.IsAuthenticated)
            {
                var returnUrl = NavigationManager.QueryString("returnUrl");
                NavigationManager.NavigateTo(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "/", forceLoad: true);
            }
            else
            {
                Message.Error("Invalid credentials");
            }
        }
        catch (ApiException e)
        {
            Message.Error(e.Detail);
        }
    }
}