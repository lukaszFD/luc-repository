﻿using System.Web;
using System.Web.Mvc;

namespace Studia.HTML5.Przyklad4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
