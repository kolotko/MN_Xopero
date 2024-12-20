using Xopero.Contracts.Models;

namespace Xopero.Contracts.Responses;

public class CreateIssueResponseDto : GitIssueDto
{
    public int? Id { get; set; }
}