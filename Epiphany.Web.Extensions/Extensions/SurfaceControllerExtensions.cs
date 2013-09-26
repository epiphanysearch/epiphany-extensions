using System;
using System.IO;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace Epiphany.Web.Extensions
{
    public static class SurfaceControllerExtensions
    {
        /// <summary>
        /// Return a string of the rendered Razor view
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="view">Name of the view. (This is passed to the Razor ViewEngine)</param>
        /// <param name="model">Model that is used when rendering the view</param>
        /// <returns>Rendered Content</returns>
        /// <remarks>
        /// This is useful to render the contents of a Razor view into a string, which can then be used for example as an email body.
        /// </remarks>
        public static string RenderView(this SurfaceController controller, string view, object model)
        {
            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, view);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        /// <summary>
        /// Send an email using a Razor template as the body of the email
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="razorTemplate"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static void SendRazorEmail(this SurfaceController controller, string to, string subject, string razorTemplate, object model)
        {
            var from = umbraco.UmbracoSettings.NotificationEmailSender;
            var body = RenderView(controller, razorTemplate, model);
            umbraco.library.SendMail(from, to, subject, body, true);
        }

        /// <summary>
        /// Log a debug message
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="msg"></param>
        public static void LogDebug(this SurfaceController controller, string msg)
        {
            LogHelper.Debug(controller.GetType(), msg);
        }

        /// <summary>
        /// Log an exception
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="msg"></param>
        /// <param name="e"></param>
        public static void LogError(this SurfaceController controller, string msg, Exception e)
        {
            LogHelper.Error(controller.GetType(), msg, e);
        }
    }
}