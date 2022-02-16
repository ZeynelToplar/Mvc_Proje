using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;
using System.Threading;

namespace Mvc_Proje_Kampi.Controllers.WriterPanel
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        WriterValidator writerValidator = new WriterValidator();
        Context c = new Context();
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string mail = (string)Session["WriterMail"];
            ViewBag.d = mail;
            id = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.a = id;
            var writerValue = wm.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = writerValidator.Validate(writer);
            if (results.IsValid)
            {
                wm.UpdateWriter(writer);
                return RedirectToAction("AllHeadings", "WriterPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string mail)
        {         
            mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            int id = writerIdInfo;
            var headings = hm.GetHeadingsByWriter(id);
            return View(headings);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            
            List<SelectListItem> valueCategory = GetCategoriesForDropdown();
            ViewBag.valueC = valueCategory;
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
        public ActionResult NewHeading(Heading heading)
        {
            string mail = (string)Session["WriterMail"];
            var writerIdInfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            int id = writerIdInfo;
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = id;
            heading.HeadingStatus = true;
            hm.AddHeading(heading);
            Thread.Sleep(3000);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var heading = hm.GetById(id);
            hm.DeleteHeading(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeadings(int page = 1)
        {
            var headings = hm.GetHeadings().ToPagedList(page, 4);
            return View(headings);
        }
    }
}