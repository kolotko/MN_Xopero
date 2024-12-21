using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Xopero.Abstraction.Services;
using Xopero.Contracts.Requests;
using Xopero.Contracts.Responses;
using Xopero.Mapping;
using Xopero.Models.Enums;

namespace Xopero.Api.Endpoints.GitIssues;

public static class UpdateIssueEndpoint
{
    private const string Name = "UpdateIssue";

    public static IEndpointRouteBuilder MapUpdateIssue(this IEndpointRouteBuilder app)
    {
        app.MapPut(ApiEndpoints.GitIssues.Update, async (
                [AsParameters] UpdateIssueParametersRequest parameters,
                [FromBody] UpdateIssueRequest request,
                IGitIssueService gitIssueService,
                IValidator<UpdateIssueRequest> updateIssueRequestValidator,
                CancellationToken cancellationToken) =>
            {
                var validationDtoResult = await updateIssueRequestValidator.ValidateAsync(request, cancellationToken);
                if (!validationDtoResult.IsValid)
                {
                    return Results.ValidationProblem(validationDtoResult.ToDictionary());
                }
                
                var model = request.MapToGitIssue(parameters.Id!.Value);
                var result = await gitIssueService.UpdateIssueForRepository((EHostingService)parameters.HostingService!, model, cancellationToken);
                if (result.IsSuccess)
                {
                    return TypedResults.Ok(result.Body!.MapToUpdateIssueResponse());
                }
                return TypedResults.Problem(result.Message, statusCode: StatusCodes.Status400BadRequest);
            })
            .WithName(Name)
            .Produces<UpdateIssueResponseDto>(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}