namespace Xopero.Api.Endpoints.GitIssues;

public static class UpdateIssueEndpoint
{
    private const string Name = "UpdateIssue";

    public static IEndpointRouteBuilder MapUpdateIssue(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.GitIssues.Update, async (CancellationToken token) =>
            {
                return TypedResults.Ok();
            })
            .WithName(Name)
            .Produces(StatusCodes.Status200OK);
        // .Produces<MoviesResponse>(StatusCodes.Status200OK);
            
        return app;
    }
}