using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo2.Common
{
    public static class MenuHelper
    {
        public static string sayHi(this HtmlHelper helper)
        {
            return "Hello HTML";
        }
    }
}