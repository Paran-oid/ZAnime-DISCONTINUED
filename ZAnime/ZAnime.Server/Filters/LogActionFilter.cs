using Microsoft.AspNetCore.Mvc.Filters;

namespace Zanime.Server.Filters
{
    public class MyLogFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} is getting executed from {context.Controller.GetType().Name} ...");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} from {context.Controller.GetType().Name} successfully executed!");
        }
    }
}