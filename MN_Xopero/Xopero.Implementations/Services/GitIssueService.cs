using Xopero.Abstraction.Factories;
using Xopero.Abstraction.Services;
using Xopero.Models;
using Xopero.Models.Enums;

namespace Xopero.Implementations.Services;

public class GitIssueService(IGitHostingServiceFactory gitHostingServiceFactory) : IGitIssueService
{
    public async Task<IEnumerable<GitIssue>> GetAllIssuesForRepository(EHostingService hostingService, CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var allIssues = await externalGitHosting.GetAllIssues(cancellationToken);

        if (allIssues is not null)
        {
            return allIssues;
        }
        
        return [];
    }

    public async Task<Result<GitIssue>> GetIssueForRepository(EHostingService hostingService, int id, CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var issue = await externalGitHosting.GetIssue(id, cancellationToken);
        if (issue is null)
        {
            return new Result<GitIssue>()
            {
                IsSuccess = false,
                Message = "Can't find issue." //TODO location
            };
        }

        return new Result<GitIssue>()
        {
            IsSuccess = true,
            Body = issue!
        };
    }

    public async Task<Result<GitIssue>> CreateIssueForRepository(EHostingService hostingService, GitIssue gitIssue, CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var issue = await externalGitHosting.CreateIssue(gitIssue, cancellationToken);
        if (issue is null)
        {
            return new Result<GitIssue>()
            {
                IsSuccess = false,
                Message = "Can't create issue." //TODO location
            };
        }

        return new Result<GitIssue>()
        {
            IsSuccess = true,
            Body = issue!
        };
    }
}