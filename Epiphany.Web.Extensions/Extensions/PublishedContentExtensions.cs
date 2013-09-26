using System;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Epiphany.Web.Extensions
{
    public static class PublishedContentExtensions
    {
        /// <summary>
        /// Return a IHtmlString for a property
        /// </summary>
        /// <param name="publishedContent"></param>
        /// <param name="propertyName"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static IHtmlString PropertyToHtmlString(this IPublishedContent publishedContent, string propertyName, string fallback)
        {
            var value = publishedContent.GetPropertyValue(propertyName, fallback).ToString();
            return new MvcHtmlString(value);
        }

        public static IHtmlString PropertyToHtmlString(this IPublishedContent publishedContent, string propertyName)
        {
            return PropertyToHtmlString(publishedContent, propertyName, String.Empty);
        }
    }
}