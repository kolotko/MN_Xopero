using System.Net.Http.Headers;
using GitHosting.Bitbucket;
using GitHosting.GitHub;
using Microsoft.Extensions.Options;
using Xopero.Abstraction.Factories;
using Xopero.Abstraction.GitHosting;
using Xopero.Abstraction.Services;
using Xopero.Api.Handlers;
using Xopero.Implementations.Factories;
using Xopero.Implementations.Services;
using Xopero.Models.Settings;

namespace Xopero.Api;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.Configure<GitHubSettings>(configurationManager.GetSection(GitHubSettings.GitHubSectionName));
        services.Configure<BitbucketSettings>(configurationManager.GetSection(BitbucketSettings.BitbucketSectionName));
        return services;
    }
    
    public static IServiceCollection AddApplicationImplementation(this IServiceCollection services)
    {
        services.AddTransient<HttpLoggerHandler>();
        services.AddScoped<IGitIssueService, GitIssueService>();
        services.AddScoped<IGitHostingServiceFactory, GitHostingServiceFactory>();
        return services;
    }
    
    public static IServiceCollection AddHttpClientService(this IServiceCollection services)
    {
        // todo; dodać retry policy
        services.AddHttpClient<IExternalGitHostingAdapter, GitHubAdapter>((serviceProvider, client) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<GitHubSettings>>().Value;
            client.BaseAddress = new Uri(settings.Url!);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.Token);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", settings.UserAgentName)); // bez tego 403 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(settings.Accept!));
        }).SetHandlerLifetime(TimeSpan.FromSeconds(5))
        .AddHttpMessageHandler<HttpLoggerHandler>();
        
        
        services.AddHttpClient<IExternalGitHostingAdapter, BitbucketAdapter>((serviceProvider, client) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<BitbucketSettings>>().Value;
            client.BaseAddress = new Uri(settings.Url!);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.Token);
        });
        
        return services;
    }
}