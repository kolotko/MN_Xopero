using System.Text.Json.Serialization;

namespace Xopero.Contracts.GitHosting.GitLab;

public class GitLabIssueDto
{
    [JsonPropertyName("iid")]
    public int? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("description")]
    public string? Body { get; set; }
    
    [JsonPropertyName("web_url")]
    public string? HtmlUrl { get; set; }
}