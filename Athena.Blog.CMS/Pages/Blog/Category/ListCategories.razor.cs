using System;
using System.Threading.Tasks;
using AntDesign;
using Athena.Blog.CMS.Helpers;
using Athena.Blog.CMS.HttpRepositories;
using Athena.Blog.CMS.Models;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Pages.Blog.Category;

public partial class ListCategories : IDisposable
{
    [Inject]
    public HttpInterceptorService HttpInterceptor { get; set; }
    
    [Inject]
    public ICategoryRepository CategoryRepository { get; set; }
    
    [Inject]
    public MessageService Message { get; set; }
    
    private ViewCategoriesDto categories = new();
    
    protected override async Task OnInitializedAsync()
    {
        try
        {
            HttpInterceptor.RegisterEvent();
            var query = new GetCategoriesQuery();
            categories = await CategoryRepository.GetCategories(query);
        
            categories.Items.ForEach(x=>Console.WriteLine(x.Title));
        }
        catch(ApiException e)
        {
            await Message.Error($"{e.Detail}");
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
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