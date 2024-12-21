namespace Xopero.Models.Settings;

public class GitLabSettings
{
    public const string GitLabSectionName = "GitLabSettings";
    public string? Url { get; set; }
    public string? Token { get; set; }
    public string? ProjectId { get; set; }
}