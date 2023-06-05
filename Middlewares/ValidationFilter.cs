using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SpaceX.Middlewares
{
	public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // we can even *still* use model state properly…
            if (!context.ModelState.IsValid)
            {
                var responseObj = new
                {
                    successful = false,
                    error = "The input is not valid",
                };

                // setting the result shortcuts the pipeline, so the action is never executed
                context.Result = new JsonResult(responseObj)
                {
                    StatusCode = 400
                };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        { }
    }
}

