using Xopero.Models;
using Xopero.Models.Enums;

namespace Xopero.Abstraction.Services;

public interface IGitIssueService
{
    public Task<IEnumerable<GitIssue>> GetAllIssuesForRepository(EHostingService hostingService, CancellationToken cancellationToken = default);
}