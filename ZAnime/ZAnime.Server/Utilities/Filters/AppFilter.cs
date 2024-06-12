using Microsoft.AspNetCore.Mvc.Filters;

namespace Zanime.Server.Utilities.Filters
{
    public class AppFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("App is executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("API ready!");
        }
    }
}