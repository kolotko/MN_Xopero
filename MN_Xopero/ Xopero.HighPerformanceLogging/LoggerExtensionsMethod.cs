using Microsoft.Extensions.Logging;

namespace Xopero.HighPerformanceLogging;

public static partial class LoggerExtensionsMethod
{
    [LoggerMessage(
        Level = LogLevel.Warning, 
        Message = "Request:{requestUri}, Type:{method}, RequestBody:{content}")]
    public static partial void LogRequest(this ILogger logger, Uri? requestUri, HttpMethod method, string content);
    
    [LoggerMessage(
        Level = LogLevel.Warning, 
        Message = "ResponseBody:{content}")]
    public static partial void LogResponse(this ILogger logger, string content);
}