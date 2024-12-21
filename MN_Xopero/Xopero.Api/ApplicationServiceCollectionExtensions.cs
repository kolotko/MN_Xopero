using System.Net.Http.Headers;
using FluentValidation;
using GitHosting.GitHub;
using GitHosting.GitLab;
using Microsoft.Extensions.Options;
using Xopero.Abstraction.Factories;
using Xopero.Abstraction.GitHosting;
using Xopero.Abstraction.Services;
using Xopero.Api.Handlers;
using Xopero.Implementations.Factories;
using Xopero.Implementations.Services;
using Xopero.Models.Settings;
using Xopero.Validators;

namespace Xopero.Api;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.Configure<GitHubSettings>(configurationManager.GetSection(GitHubSettings.GitHubSectionName));
        services.Configure<GitLabSettings>(configurationManager.GetSection(GitLabSettings.GitLabSectionName));
        return services;
    }
    
    public static IServiceCollection AddApplicationValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateIssueRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<UpdateIssueRequestValidator>();
        return services;
    }
    
    public static IServiceCollection AddGlobalErrorHandling(this IServiceCollection services)
    {
        services.AddProblemDetails(options =>
            options.CustomizeProblemDetails = (context) =>
            {
                if (context.ProblemDetails.Status != 400)
                {
                    context.ProblemDetails.Status = 500;
                    context.ProblemDetails.Title = "Server Error"; //TODO: locale
                    context.ProblemDetails.Extensions = null;
                }
            }
        );
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
        // opisać dlaczego rejestrowanie na ten sam interfejs wielu instancji jest problematyczne i trzeba dodać name
        // https://stackoverflow.com/questions/74005464/add-httpclients-with-same-interface-ended-up-having-the-same-base-url-asp-net-co
        services.AddHttpClient<IExternalGitHostingAdapter, GitHubAdapter>($"{nameof(GitHubAdapter)}HttpClient", (serviceProvider, client) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<GitHubSettings>>().Value;
            client.BaseAddress = new Uri(settings.Url!);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", settings.Token);
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("product", settings.UserAgentName)); // bez tego 403 
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(settings.Accept!));
        }).SetHandlerLifetime(TimeSpan.FromSeconds(5))
        .AddHttpMessageHandler<HttpLoggerHandler>();
        
        
        services.AddHttpClient<IExternalGitHostingAdapter, GitLabAdapter>($"{nameof(GitLabAdapter)}HttpClient", (serviceProvider, client) =>
        {
            var settings = serviceProvider.GetRequiredService<IOptions<GitLabSettings>>().Value;
            client.BaseAddress = new Uri(settings.Url!);
            client.DefaultRequestHeaders.Add("PRIVATE-TOKEN",settings.Token);
        });
        
        return services;
    }
}