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
        public ActionResult Index(
            string pattern = "T v A N",
            int limit = 5,
            bool alliterate = false,
            int count = 10)
        {
            var gen = Generator.Instance;

            var patterns = new List<string>() { "T v A N|p", "A N|p", "T N|p", "V T A N|p", "A V", "V A" };

            ViewBag.Names = gen.GetNames(patterns, (int)limit, alliterate, count);
            ViewBag.Pattern = pattern;
            ViewBag.Limit = limit;
            ViewBag.Alliterate = alliterate;
            return View();
        }
    }
}
