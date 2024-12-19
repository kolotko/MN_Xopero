using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class GetAllIssuesRequest
{
    public required EHostingService? HostingService { get; set; }
}