using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Athena.Blog.CMS.Helpers;
using Athena.Blog.CMS.Models;

namespace Athena.Blog.CMS.HttpRepositories.Impl;

public class CategoryRepository : ICategoryRepository
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public CategoryRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public async Task<ViewCategoriesDto> GetCategories(GetCategoriesQuery query)
    {
        var prs = QueryStringHelper.CreateQueryString(query);
        // Get with params 
        var response = await _httpClient.GetAsync($"categories?{prs}");

        var content = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var err = JsonSerializer.Deserialize<ApiException>(content, _jsonSerializerOptions);
            throw err;
        }

        var categories = JsonSerializer.Deserialize<ViewCategoriesDto>(content, _jsonSerializerOptions);

        return categories;
    }
}