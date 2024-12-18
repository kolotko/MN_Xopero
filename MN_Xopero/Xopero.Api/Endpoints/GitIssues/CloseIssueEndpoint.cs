namespace Xopero.Api.Endpoints.GitIssues;

public static class CloseIssueEndpoint
{
    private const string Name = "CloseIssue";
    
    public static IEndpointRouteBuilder MapCloseIssue(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.GitIssues.Close, async (CancellationToken token) =>
            {
                return TypedResults.Ok();
            })
            .WithName(Name)
            .Produces(StatusCodes.Status200OK);
        // .Produces<MoviesResponse>(StatusCodes.Status200OK);
            
        return app;
    }
}