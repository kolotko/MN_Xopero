namespace Xopero.Models.Settings;

public class BitbucketSettings
{
    public const string BitbucketSectionName = "BitbucketSettings";
    public string? Url { get; set; }
    public string? Token { get; set; }
}