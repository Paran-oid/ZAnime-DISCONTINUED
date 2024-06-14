using Microsoft.AspNetCore.Mvc.Filters;

namespace Zanime.Server.Utilities.Filters
{
    public class AppFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($" EXECUTING \n {context.ActionDescriptor.DisplayName}");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{context.ActionDescriptor.DisplayName} \n EXECUTED");
        }
    }
}