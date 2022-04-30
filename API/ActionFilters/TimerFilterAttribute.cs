using Microsoft.AspNetCore.Mvc.Filters;

namespace UI.ActionFilters;

public class TimerFilterAttribute : IActionFilter
{
    private DateTime _startTime;

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _startTime = DateTime.Now;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        context.HttpContext.Response.Headers["processing_time"] =
            (DateTime.Now - _startTime).Milliseconds.ToString();
    }
}
