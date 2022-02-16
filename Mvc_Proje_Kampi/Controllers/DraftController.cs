using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class DraftController : Controller
    {
        // GET: Draft
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            string sender = (string)Session["WriterMail"];
            var messages = messageManager.GetDrafts(sender);
            return View(messages);
        }
    }
}