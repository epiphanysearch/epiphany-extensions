using System;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace Epiphany.Web.Extensions.ActionFilters
{
    public class PassStateAttribute : ActionFilterAttribute
    {
        public Type Type { get; set; }

        public string Key { get; set; }

        public PassStateAttribute(Type type)
        {
            Type = type;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid == false)
            {
                if ((filterContext.Result is RedirectResult) || (filterContext.Result is RedirectToUmbracoPageResult))
                {
                    filterContext.Controller.TempData[StateHelper.GetKey(Type, Key)] = filterContext.Controller.ViewData.ModelState;
                }
            }
            base.OnActionExecuted(filterContext);
        }
    }
}