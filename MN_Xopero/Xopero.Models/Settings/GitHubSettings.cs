namespace Xopero.Models.Settings;

public class GitHubSettings
{
    public const string GitHubSectionName = "GitHubSettings";
    public string? Url { get; set; }
    public string? Token { get; set; }
    public string? Accept { get; set; }
    public string? UserAgentName { get; set; }
}