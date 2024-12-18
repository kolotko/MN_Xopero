using Xopero.Api.Endpoints.GitIssues;

namespace Xopero.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetAllIssues();
        app.MapCreateIssue();
        app.MapUpdateIssue();
        app.MapCloseIssue();
        return app;
    }
}