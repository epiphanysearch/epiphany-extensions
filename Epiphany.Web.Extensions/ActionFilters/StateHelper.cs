using System;
using System.Web.Mvc;

namespace Epiphany.Web.Extensions.ActionFilters
{
    internal class StateHelper
    {
        private const string Key = "__ModelState_";

        public static string GetKey(Type modelType, string key)
        {
            return String.Format("{0}_{1}_{2}", Key, modelType.FullName, key);
        }
    }
}