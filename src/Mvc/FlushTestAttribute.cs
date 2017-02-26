using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Mvc
{
    public class FlushTestAttribute : ActionFilterAttribute
    {
        private readonly ILogger<FlushTestAttribute> _log;

        public FlushTestAttribute(ILogger<FlushTestAttribute> logger)
        {
            _log = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _log.LogDebug($"OnActionExecuting. Headers sent: {context.HttpContext.Response.HasStarted}");
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _log.LogDebug($"OnActionExecuted. Headers sent: {context.HttpContext.Response.HasStarted}");
            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            _log.LogDebug($"OnResultExecuting. Headers sent: {context.HttpContext.Response.HasStarted}");
            base.OnResultExecuting(context);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            _log.LogDebug($"OnResultExecuted. Headers sent: {context.HttpContext.Response.HasStarted}");
            base.OnResultExecuted(context);
        }
    }
}
