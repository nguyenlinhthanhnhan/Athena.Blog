using System.Collections.Generic;
using Athena.Blog.CMS.Models;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}