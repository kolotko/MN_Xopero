using Xopero.Models;
using Xopero.Models.Enums;

namespace Xopero.Abstraction.Services;

public interface IGitIssueService
{
    public Task<IEnumerable<GitIssue>> GetAllIssuesForRepository(EHostingService hostingService, CancellationToken cancellationToken = default);
    public Task<Result<GitIssue>> GetIssueForRepository(EHostingService hostingService, int id, CancellationToken cancellationToken = default);
    public Task<Result<GitIssue>> CreateIssueForRepository(EHostingService hostingService, GitIssue gitIssue, CancellationToken cancellationToken = default);
}