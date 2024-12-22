using Xopero.Abstraction.Factories;
using Xopero.Abstraction.Services;
using Xopero.Models;
using Xopero.Models.Enums;

namespace Xopero.Implementations.Services;

public class GitIssueService(IGitHostingServiceFactory gitHostingServiceFactory) : IGitIssueService
{
    public async Task<Result<IEnumerable<GitIssue>>> GetAllIssuesForRepository(EHostingService hostingService, CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var allIssues = await externalGitHosting.GetAllIssues(cancellationToken);
        
        if (allIssues is null)
        {
            return new Result<IEnumerable<GitIssue>>()
            {
                IsSuccess = false,
                Message = "Can't get issues."
            };
        }

        return new Result<IEnumerable<GitIssue>>()
        {
            IsSuccess = true,
            Body = allIssues!
        };
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
                Message = "Can't find issue."
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
                Message = "Can't create issue."
            };
        }

        return new Result<GitIssue>()
        {
            IsSuccess = true,
            Body = issue!
        };
    }

    public async Task<Result<GitIssue>> UpdateIssueForRepository(EHostingService hostingService, GitIssue gitIssue,
        CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var issue = await externalGitHosting.UpdateIssue(gitIssue, cancellationToken);
        if (issue is null)
        {
            return new Result<GitIssue>()
            {
                IsSuccess = false,
                Message = "Can't update issue."
            };
        }

        return new Result<GitIssue>()
        {
            IsSuccess = true,
            Body = issue!
        };
    }

    public async Task<Result> CloseIssueForRepository(EHostingService hostingService, int id, CancellationToken cancellationToken = default)
    {
        var externalGitHosting = gitHostingServiceFactory.GetExternalGitHostingAdapter(hostingService);
        var success = await externalGitHosting.CloseIssue(id, cancellationToken);
        return new Result()
        {
            IsSuccess = success,
            Message = "Can't close issue."
        };
    }
}