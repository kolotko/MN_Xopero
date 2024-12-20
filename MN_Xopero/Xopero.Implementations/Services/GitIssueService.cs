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
}