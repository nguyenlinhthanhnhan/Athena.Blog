using System;

namespace Athena.Blog.CMS.Helpers;

[Serializable]
public class ApiException : Exception
{
    public string Type { get; set; }

    public string Title { get; set; }

    public int Status { get; set; }

    public string Detail { get; set; }
}