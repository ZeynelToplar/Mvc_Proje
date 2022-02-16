using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager contentManager = new ContentManager(new EfContentDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                var allValues = contentManager.GetContents();
                return View(allValues);
            }
            var filteredvalues = contentManager.GetContents(text);
            return View(filteredvalues);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contents = contentManager.GetContentByHeading(id);
            return View(contents);
        }
    }
}