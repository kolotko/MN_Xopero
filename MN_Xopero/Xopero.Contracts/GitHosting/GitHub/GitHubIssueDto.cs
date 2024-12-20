using System.Text.Json.Serialization;

namespace Xopero.Contracts.GitHosting.GitHub;

public class GitHubIssueDto
{
    [JsonPropertyName("number")]
    public int? Number { get; set; }
    
    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; set; }
    
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("pull_request")]
    public object? PullRequest { get; set; }
}