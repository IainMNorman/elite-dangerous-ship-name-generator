using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string pattern = "T v A N", int? limit = 5, bool alliterate = false)
        {
            if (String.IsNullOrWhiteSpace(pattern))
                pattern = "T v A N";

            if (limit == null)
                limit = 0; 

            var gen = Generator.Instance;

            ViewBag.Name = gen.GetName(pattern, (int)limit, alliterate);
            ViewBag.Pattern = pattern;
            ViewBag.Limit = limit;
            ViewBag.Alliterate = alliterate;
            return View();
        }
    }
}
