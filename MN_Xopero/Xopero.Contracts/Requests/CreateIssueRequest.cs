using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class CreateIssueRequest
{
    public EHostingService? HostingService { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}