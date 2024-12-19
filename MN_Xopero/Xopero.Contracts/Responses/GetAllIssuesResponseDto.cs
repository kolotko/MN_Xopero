using Xopero.Contracts.Models;

namespace Xopero.Contracts.Responses;

public class GetAllIssuesResponseDto
{
    public GitIssueDto[]? GitIssues { get; set; }
}