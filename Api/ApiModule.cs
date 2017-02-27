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
        private Generator gen = Generator.Instance;

        public ApiModule() : base("/api")
        {
            Get["/names"] = p => GetNames(10, 5, false, "T v A N|p,A N|p,T N|p,V T A N|p,A V,V A");
            Get["/names/{count}/{limit}/{alliterate}/{patterns}"] = p => GetNames(p.count, p.limit, p.alliterate, p.patterns);
        }

        private dynamic GetNames(int count, int limit, bool alliterate, string patterns)
        {
            if (count > 50) count = 50;
            var patternsSplit = patterns.Split(',').ToList();
            return Response.AsJson(gen.GetNames(patternsSplit, limit, alliterate, count));
        }
    }
}