using Xopero.Models;

namespace Xopero.Abstraction.GitHosting;

public interface IExternalGitHostingAdapter
{
    public Task<IEnumerable<GitIssue>?> GetAllIssues(CancellationToken cancellationToken = default);
    public Task<GitIssue?> GetIssue(int id, CancellationToken cancellationToken = default);
    public Task<GitIssue?> CreateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default);
    public Task<GitIssue?> UpdateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default);
    public Task<GitIssue?> CloseIssue(int id, CancellationToken cancellationToken = default);
}