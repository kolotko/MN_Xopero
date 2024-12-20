using System.Text.Json.Serialization;

namespace Xopero.Contracts.GitHosting.GitHub;

public class GitHubCloseIssueDto
{
    [JsonPropertyName("state")]
    public string? State { get; set; }
}