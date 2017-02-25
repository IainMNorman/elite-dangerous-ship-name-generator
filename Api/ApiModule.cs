using Api.Models;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api
{
    public class ApiModule : NancyModule
    {
        public ApiModule() : base("/api")
        {
            Get["/name"] = parameters => GetName();
        }

        private object GetName()
        {
            var gen = Generator.Instance;
            var patterns = new List<string>() { "T v A N|p", "A N|p", "T N|p", "V T A N|p", "A V", "V A" };
            var names = gen.GetNames(patterns, 5, false, 5);
            return this.Response.AsJson(names);
        }
    }
}