using Athena.Shared.DTOs;
using Athena.Shared.ViewModels.Category;

namespace Athena.Blog.CMS.Models;

public class ViewCategoryDto : IViewCategoryDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string MetaTitle { get; set; }
    
    public string Slug { get; set; }
    
    public string Content { get; set; }
}