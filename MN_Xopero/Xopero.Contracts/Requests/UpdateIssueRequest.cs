using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class UpdateIssueRequest
{
    public string? Title { get; set; }
    public string? Body { get; set; }
}