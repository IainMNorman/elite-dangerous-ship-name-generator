using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get[@"/"] = parameters =>
            {
                return Response.AsFile("Webroot/index.html", "text/html");
            };
        }
    }
}