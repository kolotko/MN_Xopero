using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Xopero.Abstraction.Services;
using Xopero.Contracts.Requests;
using Xopero.Contracts.Responses;
using Xopero.Mapping;
using Xopero.Models.Enums;

namespace Xopero.Api.Endpoints.GitIssues;

public static class GetIssueEndpoint
{
    public const string Name = "GetIssue";

    public static IEndpointRouteBuilder MapGetIssue(this IEndpointRouteBuilder app)
    {
        app.MapGet(ApiEndpoints.GitIssues.Get, async (
                [AsParameters] GetIssueRequest request,
                IGitIssueService gitIssueService,
                IValidator<GetIssueRequest> getIssueRequestValidator,
                CancellationToken cancellationToken) =>
            {
                var validationDtoResult = await getIssueRequestValidator.ValidateAsync(request, cancellationToken);
                if (!validationDtoResult.IsValid)
                {
                    return Results.ValidationProblem(validationDtoResult.ToDictionary());
                }

                var issue = await gitIssueService.GetIssueForRepository((EHostingService)request.HostingService!, request.Id!.Value, cancellationToken);
                if (issue.IsSuccess)
                {
                    return TypedResults.Ok(issue.Body!.MapToGetIssueResponse());
                }
                return TypedResults.Problem(issue.Message, statusCode: StatusCodes.Status400BadRequest);
            })
            .WithName(Name)
            .Produces<GetIssueResponseDto>(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}