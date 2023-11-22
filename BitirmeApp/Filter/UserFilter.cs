using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BitirmeApp.Filter
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userid=context.HttpContext.Session.GetInt32("İd");
            if(!userid.HasValue){
                context.Result=new RedirectToRouteResult(new RouteValueDictionary{
                  {"action","Index"},
                  {"controller","Kullanici"}    
                });
             
            }
            base.OnActionExecuting(context);
        }
    }
}
