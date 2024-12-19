using Xopero.HighPerformanceLogging;

namespace Xopero.Api.Handlers;

public class HttpLoggerHandler : DelegatingHandler
{
    private ILogger<HttpLoggerHandler> _logger;
    public HttpLoggerHandler(ILogger<HttpLoggerHandler> logger)
    {
        _logger = logger;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // w przypadku metody get nie ma contentu
        var requestBody = request.Content is not null ? await request.Content.ReadAsStringAsync(cancellationToken) : "";
        _logger.LogRequest(request.RequestUri, request.Method, requestBody);

        var response = await base.SendAsync(request, cancellationToken);

        var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);
        _logger.LogResponse(responseBody);

        return response;
    }
}