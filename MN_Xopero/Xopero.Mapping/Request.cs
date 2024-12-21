using Xopero.Contracts.Requests;
using Xopero.Models;

namespace Xopero.Mapping;

public static class Request
{
    public static GitIssue MapToGitIssue(this CreateIssueRequest dto)
    {
        return new GitIssue()
        {
            Title = dto.Title,
            Body = dto.Body,
        };
    }
    public static GitIssue MapToGitIssue(this UpdateIssueRequest dto, int id)
    {
        return new GitIssue()
        {
            Number = id,
            Title = dto.Title,
            Body = dto.Body,
        };
    }
}