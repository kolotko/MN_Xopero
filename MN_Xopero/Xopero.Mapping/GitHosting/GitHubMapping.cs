using Xopero.Contracts.GitHosting.GitHub;
using Xopero.Contracts.GitHosting.GitLab;
using Xopero.Models;

namespace Xopero.Mapping.GitHosting;

public static class GitHubMapping
{
    public static IEnumerable<GitIssue> MapToGitIssue(this IEnumerable<GitHubIssueDto> dto)
    {
        return dto.Select(x => new GitIssue
        {
            Number = x.Number,
            Title = x.Title,
            Body = x.Body,
            HtmlUrl = x.HtmlUrl
        });
    }

    public static IEnumerable<GitIssue> MapToGitIssue(this IEnumerable<GitLabIssueDto> dto)
    {
        return dto.Select(x => new GitIssue
        {
            Number = x.Id,
            Title = x.Title,
            Body = x.Body,
            HtmlUrl = x.HtmlUrl
        });
    }
    
    public static GitHubIssueDto MapToGitHubIssueDto(this GitIssue model)
    {
        return new GitHubIssueDto
        {
            Number = model.Number,
            Title = model.Title,
            Body = model.Body,
            HtmlUrl = model.HtmlUrl
        };
    }
    
    public static GitLabIssueDto MapToGitLabIssueDto(this GitIssue model)
    {
        return new GitLabIssueDto
        {
            Id = model.Number,
            Title = model.Title,
            Body = model.Body,
            HtmlUrl = model.HtmlUrl
        };
    }
    
    public static GitIssue MapToGitIssue(this GitHubIssueDto dto)
    {
        return new GitIssue
        {
            Number = dto.Number,
            Title = dto.Title,
            Body = dto.Body,
            HtmlUrl = dto.HtmlUrl
        };
    }
    
    public static GitIssue MapToGitIssue(this GitLabIssueDto dto)
    {
        return new GitIssue
        {
            Number = dto.Id,
            Title = dto.Title,
            Body = dto.Body,
            HtmlUrl = dto.HtmlUrl
        };
    }
}