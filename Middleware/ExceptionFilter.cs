using AspDotNetStarter.Exception;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetStarter.Middleware
{
    public class ExceptionFilter : IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is ValidationException)
            {
                ValidationException ex = (ValidationException)context.Exception;
                ObjectResult objectResult = new ObjectResult(ex.Messages);
                objectResult.StatusCode = ex.Status;
                context.Result = objectResult;
                context.ExceptionHandled = true;
            } else if (context.Exception is NotFoundException)
            {
                NotFoundException ex = (NotFoundException)context.Exception;
                ObjectResult objectResult = new ObjectResult(ex.Message);
                objectResult.StatusCode = 404;
                context.Result = objectResult;
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
