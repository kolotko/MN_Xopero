using Xopero.Contracts.Models;

namespace Xopero.Contracts.Requests;

public class UpdateIssueParametersRequest
{
    public EHostingService? HostingService { get; set; }
    public int? Id { get; set; }
}