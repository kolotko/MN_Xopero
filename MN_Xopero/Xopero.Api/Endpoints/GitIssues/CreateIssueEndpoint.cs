using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Xopero.Abstraction.Services;
using Xopero.Contracts.Requests;
using Xopero.Contracts.Responses;
using Xopero.Mapping;
using Xopero.Models.Enums;

namespace Xopero.Api.Endpoints.GitIssues;

public static class CreateIssueEndpoint
{
    private const string Name = "CreateIssue";
    
    public static IEndpointRouteBuilder MapCreateIssue(this IEndpointRouteBuilder app)
    {
        app.MapPost(ApiEndpoints.GitIssues.Create, async (
                [AsParameters] CreateIssueRequest request,
                IValidator<CreateIssueRequest> createIssueValidator,
                IGitIssueService gitIssueService,
                CancellationToken cancellationToken) =>
            {
                var validationDtoResult = await createIssueValidator.ValidateAsync(request, cancellationToken);
                if (!validationDtoResult.IsValid)
                {
                    return Results.ValidationProblem(validationDtoResult.ToDictionary());
                }

                var model = request.MapToGitIssue();
                var result = await gitIssueService.CreateIssueForRepository((EHostingService)request.HostingService!, model, cancellationToken);
                if (result.IsSuccess)
                {
                    return TypedResults.CreatedAtRoute(result.Body!.MapToCreateIssueResponse(), GetIssueEndpoint.Name, new { hostingService = request.HostingService!, id = 1 } );
                }
                return TypedResults.Problem(result.Message, statusCode: StatusCodes.Status400BadRequest);
            })
            .WithName(Name)
            .Produces<CreateIssueResponseDto>(StatusCodes.Status201Created)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}