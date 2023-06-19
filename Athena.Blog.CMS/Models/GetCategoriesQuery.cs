using Athena.Shared.CQRS.QueryModels.Category;
using Athena.Shared.DTOs;

namespace Athena.Blog.CMS.Models;

public class GetCategoriesQuery : PageOptionDto, IGetCategoriesQuery
{
    public string Title { get; set; }
}