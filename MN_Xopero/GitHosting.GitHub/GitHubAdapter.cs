using System.Net.Http.Json;
using Xopero.Abstraction.GitHosting;
using Xopero.Contracts.GitHosting.GitHub;
using Xopero.Mapping.GitHosting;
using Xopero.Models;

namespace GitHosting.GitHub;

public class GitHubAdapter(HttpClient httpClient) : IExternalGitHostingAdapter
{
    public async Task<IEnumerable<GitIssue>?> GetAllIssues(CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync("", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var allIssues =  await response.Content.ReadFromJsonAsync<GitHubIssueDto[]>(cancellationToken);
        var issuesWithoutPullRequest =  allIssues?.Where(x => x.PullRequest is null).ToArray();
        return issuesWithoutPullRequest?.MapToGitIssue();
    }
}