using Xopero.Models;
using Xopero.Models.Enums;

namespace Xopero.Abstraction.Services;

public interface IGitIssueService
{
    public Task<Result<IEnumerable<GitIssue>>> GetAllIssuesForRepository(EHostingService hostingService, CancellationToken cancellationToken = default);
    public Task<Result<GitIssue>> GetIssueForRepository(EHostingService hostingService, int id, CancellationToken cancellationToken = default);
    public Task<Result<GitIssue>> CreateIssueForRepository(EHostingService hostingService, GitIssue gitIssue, CancellationToken cancellationToken = default);
    public Task<Result<GitIssue>> UpdateIssueForRepository(EHostingService hostingService, GitIssue gitIssue, CancellationToken cancellationToken = default);
    public Task<Result> CloseIssueForRepository(EHostingService hostingService, int id, CancellationToken cancellationToken = default);
}