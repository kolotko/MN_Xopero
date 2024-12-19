using Xopero.Abstraction.Services;
using Xopero.Contracts.Models;
using Xopero.Contracts.Requests;
using Xopero.Mapping;
using EHostingService = Xopero.Models.Enums.EHostingService;

namespace Xopero.Api.Endpoints.GitIssues;

public static class GetAllIssuesEndpoint
{
    private const string Name = "GetAllIssues";

    public static IEndpointRouteBuilder MapGetAllIssues(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.GitIssues.GetAll, async (
                [AsParameters] GetAllIssuesRequest request,
                IGitIssueService gitIssueService,
                CancellationToken cancellationToken) =>
        {
            // walidacja,
            var issues = await gitIssueService.GetAllIssuesForRepository(EHostingService.GitHub, cancellationToken);
            return TypedResults.Ok(issues.MapToGitIssueDto());
        })
        .WithName(Name)
        .Produces<GitIssueDto[]>(StatusCodes.Status200OK)
        .Produces<GitIssueDto[]>(StatusCodes.Status400BadRequest); //TODO
            
        return app;
    }
}