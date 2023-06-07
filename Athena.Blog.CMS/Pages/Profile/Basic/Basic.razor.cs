using System.Threading.Tasks;
using Athena.Blog.CMS.Models;
using Athena.Blog.CMS.Services;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Profile
{
    public partial class Basic
    {
        private BasicProfileDataType _data = new BasicProfileDataType();

        [Inject] protected IProfileService ProfileService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            _data = await ProfileService.GetBasicAsync();
        }
    }
}