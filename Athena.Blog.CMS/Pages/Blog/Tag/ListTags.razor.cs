using System;
using Athena.Blog.CMS.HttpRepositories;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Blog.Tag;

public partial class ListTags : IDisposable
{
    [Inject] public HttpInterceptorService HttpInterceptor { get; set; }


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