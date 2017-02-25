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
        private List<string> patterns = new List<string>() { "T v A N|p", "A N|p", "T N|p", "V T A N|p", "A V", "V A" };
        private Generator gen = Generator.Instance;

        public ApiModule() : base("/api")
        {
            Get["/name"] = p => GetName();
            Get["/names"] = p => GetNames(10);
            Get["/names/{count}"] = p => GetNames(p.count);
        }

        private dynamic GetNames(int count)
        {
            return Response.AsJson(gen.GetNames(patterns, 5, false, count));
        }

        private object GetName()
        {
            return Response.AsJson(gen.GetNames(patterns, 5, false, 1).First());
        }
    }
}