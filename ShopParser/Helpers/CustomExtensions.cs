﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace ShopParser.Helpers
{
    public static class CustomExtensions
    {
        public static MvcHtmlString MenuLink(
    this HtmlHelper htmlHelper,
    string linkText,
    string actionName,
    string controllerName
)
        {
            string currentAction = htmlHelper.ViewContext.RouteData.GetRequiredString("action");
            string currentController = htmlHelper.ViewContext.RouteData.GetRequiredString("controller");
            if (actionName == currentAction && controllerName == currentController)
            {
                return htmlHelper.ActionLink(
                    linkText,
                    actionName,
                    controllerName,
                    null,
                    new
                    {
                        @class = "btn-default"
                    });
            }
            return htmlHelper.ActionLink(linkText, actionName, controllerName);
        }
    }
}