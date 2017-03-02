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
            Get["/names"] = p => GetNames(10, 22, 5, false, "T v A N,A N,T N,V T A N,A V,V A");
            Get["/names/{count}/{length}/{limit}/{alliterate}/{patterns}"] = p => GetNames(p.count, p.length, p.limit, p.alliterate, p.patterns);
        }

        private dynamic GetNames(int count, int length, int limit, bool alliterate, string patterns)
        {
            if (count > 50) count = 50;
            var patternsSplit = patterns.Split(',').ToList();
            return Response.AsJson(gen.GetNames(patternsSplit, length, limit, alliterate, count));
        }
    }
}