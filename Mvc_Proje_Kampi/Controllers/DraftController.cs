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
            var messages = messageManager.GetMessagesSenbox().Where(x => x.IsDraft == true).ToList();
            return View(messages);
        }
    }
}