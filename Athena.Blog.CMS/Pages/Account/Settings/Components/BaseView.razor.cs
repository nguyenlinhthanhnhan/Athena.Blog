using System.Threading.Tasks;
using Athena.Blog.CMS.Models;
using Athena.Blog.CMS.Services;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Account.Settings
{
    public partial class BaseView
    {
        private CurrentUser _currentUser = new CurrentUser();

        [Inject] protected IUserService UserService { get; set; }

        private void HandleFinish()
        {
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _currentUser = await UserService.GetCurrentUserAsync();
        }
    }
}