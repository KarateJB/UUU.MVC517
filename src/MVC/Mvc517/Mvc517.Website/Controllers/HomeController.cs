using Mvc517.Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc517.Website.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string myName)
        {
            Debug.WriteLine($"myName");

            var viewModel = new Opera() {
                Id = 1,
                Title = "歌劇魅影",
                Year = 2017,
                Composer = "Big boss"
            };

            return View(viewModel);
        }
        
    }
}
