using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class GetIssueRequest
{
    public int? Id { get; set; }
    public EHostingService? HostingService { get; set; }
}