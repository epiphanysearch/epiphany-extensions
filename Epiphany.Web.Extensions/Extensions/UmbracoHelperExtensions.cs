using System;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using uComponents.DataTypes.UrlPicker;

namespace RunForAll.Web.Extensions
{
    public static class UmbracoHelperExtensions
    {
        /// <summary>
        /// Extracts the link from a uComponents URL picker
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="pickerData">the URL Picker data from Umbraco</param>
        /// <param name="defaultUrl">the default thing to link to if the URL picker doesn't have a value set</param>
        /// <returns>URL as a string</returns>
        public static string UrlPickerUrl(this UmbracoHelper helper, string pickerData, string defaultUrl)
        {
            var url = defaultUrl;
            var urlPicker = uComponents.DataTypes.UrlPicker.Dto.UrlPickerState.Deserialize(pickerData);
            if (urlPicker == null) return url;
            if (!String.IsNullOrEmpty(urlPicker.Url)) return urlPicker.Url;
            if (urlPicker.NodeId == null || urlPicker.NodeId == 0) return url;

            var nodeId = (int)urlPicker.NodeId;
            switch (urlPicker.Mode)
            {
                case UrlPickerMode.Content:
                    url = helper.NiceUrl(nodeId);
                    break;
                case UrlPickerMode.Media:
                    var media = helper.TypedMedia(nodeId);
                    if (media == null || media.GetProperty("umbracoFile") == null) return url;
                    url = media.GetPropertyValue<string>("umbracoFile");
                    break;
            }
            return url;
        }

        /// <summary>
        /// Return an Umbraco pre-value as a IHtmlString
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static IHtmlString PreValue(this UmbracoHelper helper, int val)
        {
            return new MvcHtmlString(umbraco.library.GetPreValueAsString(val));
        }
    }
}