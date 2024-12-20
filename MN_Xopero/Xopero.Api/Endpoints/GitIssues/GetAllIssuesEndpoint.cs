using FluentValidation;
using Microsoft.AspNetCore.Mvc;
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
                IValidator<GetAllIssuesRequest> getAllIssuesRequestValidator,
                CancellationToken cancellationToken) =>
        {
            var validationDtoResult = await getAllIssuesRequestValidator.ValidateAsync(request, cancellationToken);
            if (!validationDtoResult.IsValid)
            {
                return Results.ValidationProblem(validationDtoResult.ToDictionary());
            }

            var issues = await gitIssueService.GetAllIssuesForRepository(EHostingService.GitHub, cancellationToken);
            return TypedResults.Ok(issues.MapToGitIssueDto());
        })
        .WithName(Name)
        .Produces<GitIssueDto[]>(StatusCodes.Status200OK)
        .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}