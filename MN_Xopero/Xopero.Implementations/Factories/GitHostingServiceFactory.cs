using GitHosting.GitHub;
using GitHosting.GitLab;
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
            case EHostingService.GitLab:
                return externalGitHostingAdapters.First(x => x is GitLabAdapter);
        }

        throw new NotImplementedException("Unknown Hosting Service");
    }
}