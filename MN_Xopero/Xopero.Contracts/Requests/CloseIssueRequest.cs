using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class CloseIssueRequest
{
    public int? Id { get; set; }
    public EHostingService? HostingService { get; set; }
}