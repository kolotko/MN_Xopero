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

    public async Task<GitIssue?> GetIssue(int id, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"/repos/kolotko/MN_Xopero/issues/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitHubIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<GitIssue?> CreateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync("", gitIssue.MapToGitHubIssueDto(), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitHubIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<GitIssue?> UpdateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PatchAsJsonAsync($"/repos/kolotko/MN_Xopero/issues/{gitIssue.Number}", gitIssue.MapToGitHubIssueDto(), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitHubIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<bool> CloseIssue(int id, CancellationToken cancellationToken = default)
    {
        var closeDto = new GitHubCloseIssueDto()
        {
            State = "closed"
        };
        var response = await httpClient.PatchAsJsonAsync($"/repos/kolotko/MN_Xopero/issues/{id}", closeDto, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}