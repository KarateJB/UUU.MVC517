using Mvc517.DAL;
using Mvc517.DAL.Models;
using Mvc517.Utility;
using Mvc517.Website.Filter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Mvc517.Website.Controllers
{
    //[HandleError(View ="Error")]
    public class HomeController : Controller
    {
        MvcDbContext _dbContext = null;

        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = View("Error");
        }


        public HomeController()
        {
            this._dbContext = new MvcDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this._dbContext.Dispose();
        }


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


        public ActionResult Video()
        {
            //return File("~/Upload/movie.mp4", "video/mp4");
            return View();
        }

        public ActionResult Demo(string name)
        {
            LogUtility.Logger.Debug($"{name}");
            return View();
        }

        [HttpGet]
        public ActionResult Filter(string searchTitle)
        {
            var viewModel = this._dbContext.Operas.Where(x => x.Title.Contains(searchTitle))
                .OrderBy(x => x.Id);
            return View("Index", viewModel);
        }


        public async Task<ActionResult> Delete(int? id)
        {

            var entity = this._dbContext.Operas.Where(x => x.Id.Equals(id.Value)).FirstOrDefault();
            if (entity != null)
            {
                this._dbContext.Operas.Remove(entity);
                this._dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        public ActionResult Create(string myName)
        {
            //Debug.WriteLine($"myName");
            var viewModel = new Opera();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Opera viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }


            using (var dbContext = new MvcDbContext())
            {
                viewModel.CreateOn = DateTime.Now;
                viewModel.UpdateOn = DateTime.Now;
                dbContext.Operas.Add(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return HttpNotFound();


            using (var dbContext = new MvcDbContext())
            {
                var viewModel = dbContext.Operas.Where(x => x.Id.Equals(id.Value)).FirstOrDefault();

                return View(viewModel);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Opera viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            using (var dbContext = new MvcDbContext())
            {
                viewModel.UpdateOn = DateTime.Now;
                dbContext.Entry(viewModel).State = System.Data.Entity.EntityState.Modified;

                //var entity = dbContext.Operas.Where(x => x.Id.Equals(viewModel.Id)).FirstOrDefault();
                //entity.Title = viewModel.Title;
                //entity.Year = viewModel.Year;
                //entity.Composer = viewModel.Composer;
                //entity.UpdateOn = DateTime.Now;
                
                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="myName"></param>
        /// <returns></returns>
        [LogFilter]
        public ActionResult Index()
        {
            throw new Exception("sdfsdf");

            Debug.WriteLine("Now is in the Action");

            using (var dbContext = new MvcDbContext())
            {
                var viewModel = dbContext.Operas.ToList();
                return View(viewModel);
            }
        }

    }
}
