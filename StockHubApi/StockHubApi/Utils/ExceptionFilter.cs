using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

/// <inheritdoc />
public class ExceptionFilter : IExceptionFilter
{
    private readonly ILogger<ExceptionFilter> logger;

    /// <summary>
    /// The default constructor for creating a new instance of <see cref="ExceptionFilter" />.
    /// </summary>
    /// <param name="logger">The via dependency injection loaded <see cref="ILogger" />.</param>
    public ExceptionFilter(ILogger<ExceptionFilter> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public void OnException(ExceptionContext context)
    {
        HttpStatusCode status;
        string message;

        var exceptionType = context.Exception.GetType();

        if (exceptionType == typeof(BadHttpRequestException))
        {
            message = "Bad request.";
            status = HttpStatusCode.BadRequest;
        }
        else if (exceptionType == typeof(NotImplementedException))
        {
            message = "A server error occurred.";
            status = HttpStatusCode.NotImplemented;
        }
        else
        {
            message = context.Exception.Message;
            status = HttpStatusCode.InternalServerError;
        }

        logger.LogError(context.Exception.StackTrace);

        context.ExceptionHandled = true;

        HttpResponse response = context.HttpContext.Response;
        response.StatusCode = (int) status;
        response.ContentType = "application/json";
        string error = message;
        response.WriteAsync(error);
    }
}