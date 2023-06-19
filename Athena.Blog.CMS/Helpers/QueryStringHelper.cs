using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Components;

namespace Athena.Blog.CMS.Helpers;

public static class QueryStringHelper
{
    // Create query string from object
    public static string CreateQueryString(object obj)
    {
        var properties = obj.GetType()
            .GetProperties()
            .Where(p => p.GetValue(obj, null) != null)
            .Select(p => p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null)!.ToString()));

        return string.Join("&", properties.ToArray());
    }
    
    // Get query string from URL
    public static string QueryString(this NavigationManager navigationManager, string key)
    {
        var uri = navigationManager.ToAbsoluteUri(navigationManager.Uri);
        var query = HttpUtility.ParseQueryString(uri.Query);
        return query[key];
    }
}