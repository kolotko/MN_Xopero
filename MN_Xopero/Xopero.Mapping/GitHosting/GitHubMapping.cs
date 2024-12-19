using Xopero.Contracts.GitHosting.GitHub;
using Xopero.Models;

namespace Xopero.Mapping.GitHosting;

public static class GitHubMapping
{
    public static IEnumerable<GitIssue> MapToGitIssue(this IEnumerable<GitHubIssueDto> dto)
    {
        return dto.Select(x => new GitIssue
        {
            Title = x.Title,
            Body = x.Body,
            HtmlUrl = x.HtmlUrl
        });
    }
}