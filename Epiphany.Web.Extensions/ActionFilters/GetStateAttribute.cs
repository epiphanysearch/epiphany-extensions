using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace Epiphany.Web.Extensions.ActionFilters
{
    [DefaultProperty("Type")]
    public class GetStateAttribute : ActionFilterAttribute
    {
        public GetStateAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
        public string Key { get; set; }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var key = StateHelper.GetKey(Type, Key);
            var modelState = filterContext.Controller.TempData[key] as ModelStateDictionary;

            if (modelState != null)
            {
                if (filterContext.Result is ViewResult || filterContext.Result is PartialViewResult)
                {
                    filterContext.Controller.ViewData.ModelState.Merge(modelState);
                }
                else
                    filterContext.Controller.TempData.Remove(key);
            }

            base.OnActionExecuted(filterContext);
        }
    }
}