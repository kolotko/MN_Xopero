namespace Xopero.Api.Endpoints.GitIssues;

public static class GetAllIssuesEndpoint
{
    private const string Name = "GetAllIssues";

    public static IEndpointRouteBuilder MapGetAllIssues(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.GitIssues.GetAll, async (CancellationToken token) =>
        {
            return TypedResults.Ok();
        })
        .WithName(Name)
        .Produces(StatusCodes.Status200OK);
        // .Produces<MoviesResponse>(StatusCodes.Status200OK);
            
        return app;
    }
}