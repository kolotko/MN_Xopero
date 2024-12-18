namespace Xopero.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class GitIssues
    {
        private const string Base = $"{ApiBase}/GitIssues";
        
        public const string GetAll = Base;
        public const string Create = Base;
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Close = $"{Base}/{{id:guid}}";
    }
}