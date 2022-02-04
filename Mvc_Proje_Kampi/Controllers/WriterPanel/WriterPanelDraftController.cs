using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers.WriterPanel
{
    public class WriterPanelDraftController : Controller
    {
        // GET: WriterPanelDraft
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        public ActionResult Index()
        {
            var messages = messageManager.GetDrafts();
            return View(messages);
        }
    }
}