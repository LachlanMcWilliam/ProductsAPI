using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Attributes
{
    public class ATLSDetectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Connection.LocalPort.ToString().Contains("443"))
            {
                //throw new Exception();
            }

            base.OnActionExecuting(context);
        }
    }
}
