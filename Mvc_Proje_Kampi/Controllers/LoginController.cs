using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Mvc_Proje_Kampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        LoginManager lm = new LoginManager(new EfAdminDal());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var adminUserinfo = lm.Login(admin.AdminUserName,admin.AdminPassword);
            if (adminUserinfo!=null)
            {
                FormsAuthentication.SetAuthCookie(adminUserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminUserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                RedirectToAction("Index");
            }
            return View();
        }
    }
}