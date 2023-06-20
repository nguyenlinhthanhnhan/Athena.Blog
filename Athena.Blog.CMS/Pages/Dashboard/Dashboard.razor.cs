using System;
using System.Threading.Tasks;
using Athena.Blog.CMS.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Dashboard;

public partial class Dashboard : IDisposable
{
    [Inject]
    public HttpInterceptorService HttpInterceptor { get; set; }

    protected override Task OnInitializedAsync()
    {
        HttpInterceptor.RegisterEvent();
        return base.OnInitializedAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            HttpInterceptor.DisposeEvent();
        }
    }
}