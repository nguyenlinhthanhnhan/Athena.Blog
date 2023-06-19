namespace Athena.Blog.CMS;

public static class ApiUris
{
    public static class Categories
    {
        public const string GetCategories = "categories";
        
        public const string GetCategory = "categories/{id}";
        
        public const string CreateCategory = "categories";
        
        public const string UpdateCategory = "categories/{id}";
        
        public const string DeleteCategory = "categories/{id}";
    }

    public static class Authentication
    {
        public const string Authenticate = "authentication/auth";
        
        public const string RefreshToken = "authentication/refresh";
        
        public const string Revoke = "authentication/revoke";
    }
}