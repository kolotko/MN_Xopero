using Xopero.Abstraction.GitHosting;
using Xopero.Models;

namespace GitHosting.Bitbucket;

public class BitbucketAdapter(HttpClient httpClient) : IExternalGitHostingAdapter
{
    public Task<IEnumerable<GitIssue>?>  GetAllIssues(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<GitIssue?> GetIssue(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GitIssue?> CreateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GitIssue?> UpdateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GitIssue?> CloseIssue(int id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}