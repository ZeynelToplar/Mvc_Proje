using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headings = hm.GetHeadings();
            return View(headings);
        }
        public ActionResult HeadingReport()
        {
            var headings = hm.GetHeadings();
            return View(headings);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = GetCategoriesForDropdown();
            List<SelectListItem> valueWriter = (from x in wm.GetWriters()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterId.ToString()
                                                }).ToList();
            ViewBag.valueC = valueCategory;
            ViewBag.valueW = valueWriter;
            return View();
        }

        private List<SelectListItem> GetCategoriesForDropdown()
        {
            return (from x in cm.GetCategories()
                    select new SelectListItem
                    {
                        Text = x.CategoryName,
                        Value = x.CategoryID.ToString()
                    }).ToList();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate =DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.AddHeading(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = GetCategoriesForDropdown();
            ViewBag.valueC = valueCategory;
            var heading = hm.GetById(id);
            return View(heading);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            hm.UptadeHeading(heading);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetById(id);
            heading.HeadingStatus = heading.HeadingStatus ?
                            heading.HeadingStatus = false :
                            heading.HeadingStatus = true;
            hm.DeleteHeading(heading);
            return RedirectToAction("Index");
        }
    }
}