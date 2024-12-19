using Xopero.Abstraction.GitHosting;
using Xopero.Models;

namespace GitHosting.Bitbucket;

public class BitbucketAdapter(HttpClient httpClient) : IExternalGitHostingAdapter
{
    public Task<IEnumerable<GitIssue>?>  GetAllIssues(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}