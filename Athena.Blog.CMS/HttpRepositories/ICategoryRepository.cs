using System.Threading.Tasks;
using Athena.Blog.CMS.Models;

namespace Athena.Blog.CMS.HttpRepositories;

public interface ICategoryRepository
{
    Task<ViewCategoriesDto> GetCategories(GetCategoriesQuery query);
}