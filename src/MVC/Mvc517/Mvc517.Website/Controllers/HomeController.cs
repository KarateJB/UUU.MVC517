using Mvc517.DAL;
using Mvc517.DAL.Models;
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

        public ActionResult XmlDemo()
        {
            string data = "<Name>JB</Name><Gender>Male</Gender>";
            return Content(data, "text/xml");
        }

        public ActionResult JsonDemo()
        {
            var data = new
            {
                id = "JB",
                gender = "male",
                phone = "0933xxxxxx"
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create(string myName)
        {
            //Debug.WriteLine($"myName");
            var viewModel = new Opera();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Opera viewModel)
        {
            if (this.ModelState.IsValid)
            {
                ViewBag.IsValidateOK = "TRUE";
            }
            else
            {
                ViewBag.IsValidateOK = "FALSE";
            }


            using (var dbContext = new MvcDbContext())
            {
                viewModel.CreateOn = DateTime.Now;
                viewModel.UpdateOn = DateTime.Now;
                dbContext.Operas.Add(viewModel);
                dbContext.SaveChanges();
            }
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            //Debug.WriteLine($"myName");

            using (var dbContext = new MvcDbContext())
            {
                var viewModel = dbContext.Operas.Where(x => x.Id.Equals(id)).FirstOrDefault();

                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Opera viewModel)
        {
            using (var dbContext = new MvcDbContext())
            {
                var entity = dbContext.Operas.Where(x => x.Id.Equals(viewModel.Id)).FirstOrDefault();
                entity.Title = viewModel.Title;
                entity.Year = viewModel.Year;
                entity.Composer = viewModel.Composer;
                entity.UpdateOn = DateTime.Now;
                //viewModel.UpdateOn = DateTime.Now;
                //dbContext.Operas.Attach(viewModel);
                dbContext.SaveChanges();

                return RedirectToAction("List");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myName"></param>
        /// <returns></returns>
        public ActionResult List()
        {
            using (var dbContext = new MvcDbContext())
            {
                var viewModel = dbContext.Operas.ToList();
                return View(viewModel);
            }
        }

    }
}
