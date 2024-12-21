using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Xopero.Abstraction.GitHosting;
using Xopero.Contracts.GitHosting.GitLab;
using Xopero.Mapping.GitHosting;
using Xopero.Models;
using Xopero.Models.Settings;

namespace GitHosting.GitLab;

public class GitLabAdapter(HttpClient httpClient, IOptions<GitLabSettings> settings) : IExternalGitHostingAdapter
{
    private readonly GitLabSettings _settings = settings.Value;

    public async Task<IEnumerable<GitIssue>?> GetAllIssues(CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync("/api/v4/issues", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issues =  await response.Content.ReadFromJsonAsync<GitLabIssueDto[]>(cancellationToken);
        return issues?.MapToGitIssue();
    }

    public async Task<GitIssue?> GetIssue(int id, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"api/v4/projects/{_settings.ProjectId}/issues/{id}", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitLabIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<GitIssue?> CreateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsJsonAsync($"api/v4/projects/{_settings.ProjectId}/issues", gitIssue.MapToGitLabIssueDto(), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitLabIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<GitIssue?> UpdateIssue(GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PutAsJsonAsync($"api/v4/projects/{_settings.ProjectId}/issues/{gitIssue.Number}", gitIssue.MapToGitLabIssueDto(), cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        
        var issue =  await response.Content.ReadFromJsonAsync<GitLabIssueDto>(cancellationToken);
        return issue?.MapToGitIssue();
    }

    public async Task<bool> CloseIssue(int id, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync($"api/v4/projects/{_settings.ProjectId}/issues/{id}", cancellationToken);
        return response.IsSuccessStatusCode;
    }
}