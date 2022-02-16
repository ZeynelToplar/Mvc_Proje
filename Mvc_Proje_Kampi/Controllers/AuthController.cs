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
    public class AuthController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Auth
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAdmins();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AddAdmin(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }
    }
}