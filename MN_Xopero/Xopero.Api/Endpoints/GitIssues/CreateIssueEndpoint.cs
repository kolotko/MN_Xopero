namespace Xopero.Api.Endpoints.GitIssues;

public static class CreateIssueEndpoint
{
    private const string Name = "CreateIssue";
    
    public static IEndpointRouteBuilder MapCreateIssue(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.GitIssues.Create, async (CancellationToken token) =>
            {
                return TypedResults.Ok();
            })
            .WithName(Name)
            .Produces(StatusCodes.Status201Created);
        // .Produces<MoviesResponse>(StatusCodes.Status200OK);
            
        return app;
    }
}