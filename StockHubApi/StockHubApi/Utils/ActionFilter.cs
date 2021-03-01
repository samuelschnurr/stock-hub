using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

/// <inheritdoc />
public class ActionFilter : IActionFilter
{
    private readonly ILogger<ActionFilter> logger;

    /// <summary>
    /// The default constructor for creating a new instance of <see cref="ActionFilter" />.
    /// </summary>
    /// <param name="logger">The via dependency injection loaded <see cref="ILogger" />.</param>
    public ActionFilter(ILogger<ActionFilter> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public void OnActionExecuting(ActionExecutingContext context)
    {
        string actionLogMessage = GetActionLogMessage(context, nameof(OnActionExecuting));
        logger.LogInformation(actionLogMessage);
    }

    /// <inheritdoc />
    public void OnActionExecuted(ActionExecutedContext context)
    {
        string actionLogMessage = GetActionLogMessage(context, nameof(OnActionExecuted));
        logger.LogInformation(actionLogMessage);
    }

    private string GetActionLogMessage(FilterContext context, string sender)
    {
        if (context == null)
        {
            logger.LogWarning($"{sender}: {nameof(context)} is null");
        }

        object controllerName = context.RouteData?.Values["controller"];
        object actionName = context.RouteData?.Values["action"];

        string message =
            $"{sender} called via controller: '{controllerName}' via action: '{actionName}'";

        if (context is ActionExecutingContext actionContext && actionContext.ActionArguments?.Count > 0)
        {
            string parameters = JsonSerializer.Serialize(actionContext.ActionArguments);
            message += $" with parameters: '{parameters}'";
        }

        return message;
    }
}