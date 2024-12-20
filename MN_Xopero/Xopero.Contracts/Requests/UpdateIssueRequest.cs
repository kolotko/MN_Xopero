using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class UpdateIssueRequest
{
    public EHostingService? HostingService { get; set; }
    public int? Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}