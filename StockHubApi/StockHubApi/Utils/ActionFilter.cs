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
        logger.LogInformation($"{nameof(OnActionExecuting)}: {context?.ActionDescriptor?.DisplayName}");
    }

    /// <inheritdoc />
    public void OnActionExecuted(ActionExecutedContext context)
    {
        logger.LogInformation($"{nameof(OnActionExecuted)}: {context?.ActionDescriptor?.DisplayName}");
    }
}