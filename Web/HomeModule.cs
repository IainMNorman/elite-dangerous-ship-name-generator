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
            Get["/"] = p => "Hello World";
        }
    }
}