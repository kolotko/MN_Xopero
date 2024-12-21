namespace Xopero.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class GitIssues
    {
        private const string Base = $"{ApiBase}/GitIssues";
        
        public const string GetAll = $"{Base}/{{hostingService}}";
        public const string Create = $"{Base}/{{hostingService}}";
        public const string Get = $"{Base}/{{hostingService}}/{{id:int}}";
        public const string Update = $"{Base}/{{hostingService}}/{{id:int}}";
        public const string Close = $"{Base}/{{hostingService}}/{{id:int}}";
    }
}