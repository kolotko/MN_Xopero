﻿using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Xopero.Abstraction.Services;
using Xopero.Contracts.Requests;
using Xopero.Models.Enums;

namespace Xopero.Api.Endpoints.GitIssues;

public static class CloseIssueEndpoint
{
    private const string Name = "CloseIssue";
    
    public static IEndpointRouteBuilder MapCloseIssue(this IEndpointRouteBuilder app)
    {
        app.MapDelete(ApiEndpoints.GitIssues.Close, async (
                [AsParameters] CloseIssueRequest request,
                IGitIssueService gitIssueService,
                IValidator<CloseIssueRequest> closeIssueRequestValidator,
                CancellationToken cancellationToken) =>
            {
                var validationDtoResult = await closeIssueRequestValidator.ValidateAsync(request, cancellationToken);
                if (!validationDtoResult.IsValid)
                {
                    return Results.ValidationProblem(validationDtoResult.ToDictionary());
                }
                
                var result = await gitIssueService.CloseIssueForRepository((EHostingService)request.HostingService!, request.Id!.Value, cancellationToken);
                if (result.IsSuccess)
                {
                    return TypedResults.Ok();
                }
                return TypedResults.Problem(result.Message, statusCode: StatusCodes.Status400BadRequest);
            })
            .WithName(Name)
            .Produces(StatusCodes.Status200OK)
            .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}