using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WebApp.Helpers
{
    public static class NavHelpers
    {
        public static string IsActivePage(this IHtmlHelper html, string page)
        {
            var routeData = html.ViewContext.RouteData;
            var current = (routeData.Values["page"]?.ToString() ?? string.Empty).Trim('/');
            if (string.IsNullOrEmpty(current)) return string.Empty;
            return string.Equals(current, page.Trim('/'), StringComparison.OrdinalIgnoreCase) ? "active" : string.Empty;
        }

        public static string IsActiveSection(this IHtmlHelper html, IEnumerable<string> pages)
        {
            var routeData = html.ViewContext.RouteData;
            var current = (routeData.Values["page"]?.ToString() ?? string.Empty).Trim('/');
            if (string.IsNullOrEmpty(current)) return string.Empty;
            foreach (var p in pages)
            {
                var trimmed = p.Trim('/');
                if (string.Equals(current, trimmed, StringComparison.OrdinalIgnoreCase))
                    return "active";
                if (current.StartsWith(trimmed + "/", StringComparison.OrdinalIgnoreCase))
                    return "active";
            }
            return string.Empty;
        }
    }
}
