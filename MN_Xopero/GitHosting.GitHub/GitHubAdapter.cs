using System.Net.Http.Json;
using Xopero.Abstraction.GitHosting;
using Xopero.Contracts.GitHosting.GitHub;
using Xopero.Mapping.GitHosting;
using Xopero.Models;

namespace GitHosting.GitHub;

public class GitHubAdapter: IExternalGitHostingAdapter
{
    private readonly HttpClient _httpClient;
    public GitHubAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<IEnumerable<GitIssue>?> GetAllIssues(CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync("", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var allIssues =  await response.Content.ReadFromJsonAsync<GitHubIssueDto[]>(cancellationToken);
        var issuesWithoutPullRequest =  allIssues?.Where(x => x.PullRequest is null).ToArray();
        return issuesWithoutPullRequest?.MapToGitIssue();
    }

    public async Task<GitIssue?> GetIssue(int id, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync($"/repos/kolotko/MN_Xopero/issues/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitHubIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<GitIssue?> CreateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("", gitIssue.MapToGitIssueDto(), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitHubIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }
}