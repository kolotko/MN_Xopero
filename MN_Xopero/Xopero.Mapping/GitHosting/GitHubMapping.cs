using Xopero.Contracts.GitHosting.GitHub;
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
    
    public static GitHubIssueDto MapToGitIssueDto(this GitIssue model)
    {
        return new GitHubIssueDto
        {
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
}