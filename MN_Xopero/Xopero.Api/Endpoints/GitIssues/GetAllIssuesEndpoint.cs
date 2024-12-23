﻿using Microsoft.AspNetCore.Mvc;
using Xopero.Abstraction.Services;
using Xopero.Contracts.Requests;
using Xopero.Contracts.Responses;
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
                var result = await gitIssueService.GetAllIssuesForRepository((EHostingService)request.HostingService!, cancellationToken);
                if (result.IsSuccess)
                {
                    return TypedResults.Ok(result.Body!.MapToGetAllIssuesResponse());
                }
                return (IResult)TypedResults.Problem(result.Message, statusCode: StatusCodes.Status500InternalServerError);
            })
        .WithName(Name)
        .Produces<GetAllIssuesResponseDto>(StatusCodes.Status200OK)
        .Produces<ValidationProblemDetails>(StatusCodes.Status400BadRequest)
        .Produces<ProblemDetails>(StatusCodes.Status500InternalServerError);
            
        return app;
    }
}