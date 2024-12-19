using Xopero.Abstraction.GitHosting;
using Xopero.Models.Enums;

namespace Xopero.Abstraction.Factories;

public interface IGitHostingServiceFactory
{
    public IExternalGitHostingAdapter GetExternalGitHostingAdapter(EHostingService hostingService);
}