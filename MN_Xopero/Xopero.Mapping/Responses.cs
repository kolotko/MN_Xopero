using Xopero.Contracts.Models;
using Xopero.Models;

namespace Xopero.Mapping;

public static class Responses
{
    public static IEnumerable<GitIssueDto> MapToGitIssueDto(this IEnumerable<GitIssue> model)
    {
        return model.Select(x => new GitIssueDto
        {
            Title = x.Title,
            Body = x.Body,
            HtmlUrl = x.HtmlUrl
        });
    }
}