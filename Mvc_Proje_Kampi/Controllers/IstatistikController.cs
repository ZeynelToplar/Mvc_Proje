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
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var kategoriSayisi = cm.GetCategories().Count();
            var yazilimKategori = hm.GetHeadings().Where(x => x.CategoryID == 21).Count();
            var yazar = wm.GetWriters().Where(x => x.WriterName.Contains("a")).Count();
            var populerBaslikID = hm.GetHeadings().GroupBy(x => x.CategoryID).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            var populerKategori = cm.GetCategories().Where(x => x.CategoryID == populerBaslikID).Select(y=>y.CategoryName).FirstOrDefault();
            var aktifKategoriler = cm.GetCategories().Where(x => x.CategoryStatus == true).Count();
            var pasifKategoriler = cm.GetCategories().Where(x => x.CategoryStatus == false).Count();
            var kategoriFark = aktifKategoriler - pasifKategoriler;

            ViewBag.kategori = kategoriSayisi;
            ViewBag.yazilim = yazilimKategori;
            ViewBag.yazar = yazar;
            ViewBag.populer = populerKategori;
            ViewBag.fark = kategoriFark;
            return View();
        }
    }
}