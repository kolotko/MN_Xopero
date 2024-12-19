using GitHosting.Bitbucket;
using GitHosting.GitHub;
using Xopero.Abstraction.Factories;
using Xopero.Abstraction.GitHosting;
using Xopero.Models.Enums;

namespace Xopero.Implementations.Factories;

public class GitHostingServiceFactory(IEnumerable<IExternalGitHostingAdapter> externalGitHostingAdapters) : IGitHostingServiceFactory
{
    public IExternalGitHostingAdapter GetExternalGitHostingAdapter(EHostingService hostingService)
    {
        switch (hostingService)
        {
            case EHostingService.GitHub:
                return externalGitHostingAdapters.First(x => x is GitHubAdapter);
            case EHostingService.Bitbucket:
                return externalGitHostingAdapters.First(x => x is BitbucketAdapter);
        }

        throw new NotImplementedException("Unknown Hosting Service");
    }
}