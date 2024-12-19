using Xopero.Models;

namespace Xopero.Abstraction.GitHosting;

public interface IExternalGitHostingAdapter
{
    public Task<IEnumerable<GitIssue>?> GetAllIssues(CancellationToken cancellationToken = default);
}