﻿using System.Web;
using System.Web.Mvc;

namespace _24Hr_Challenge.WebAPI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
