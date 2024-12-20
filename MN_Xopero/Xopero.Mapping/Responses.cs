using Xopero.Contracts.Models;
using Xopero.Contracts.Responses;
using Xopero.Models;

namespace Xopero.Mapping;

public static class Responses
{
    public static GetAllIssuesResponseDto MapToGetAllIssuesResponse(this IEnumerable<GitIssue> model)
    {
        return new GetAllIssuesResponseDto()
        {
            GitIssues = model.Select(x => new GitIssueDto
            {
                Id = x.Number,
                Title = x.Title,
                Body = x.Body,
                HtmlUrl = x.HtmlUrl
            }).ToArray()
        };
    }
    
    public static CreateIssueResponseDto MapToCreateIssueResponse(this GitIssue model)
    {
        return new CreateIssueResponseDto()
        {
            Id = model.Number,
            Title = model.Title,
            Body = model.Body,
            HtmlUrl = model.HtmlUrl
        };
    }
    
    public static GetIssueResponseDto MapToGetIssueResponse(this GitIssue model)
    {
        return new GetIssueResponseDto()
        {
            Id = model.Number,
            Title = model.Title,
            Body = model.Body,
            HtmlUrl = model.HtmlUrl
        };
    }
    
    public static GetIssueResponseDto MapToUpdateIssueResponse(this GitIssue model)
    {
        return new GetIssueResponseDto()
        {
            Id = model.Number,
            Title = model.Title,
            Body = model.Body,
            HtmlUrl = model.HtmlUrl
        };
    }
}