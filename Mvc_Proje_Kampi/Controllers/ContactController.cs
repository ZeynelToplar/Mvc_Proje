using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
        ContactValidator cv = new ContactValidator();
        public ActionResult Index()
        {
            var contacts = cm.GetContacts();
            return View(contacts);
        }
        public ActionResult GetContactDetails(int id)
        {
            var contact = cm.GetById(id);
            return View(contact);
        }
        public PartialViewResult MessageBoxPartial()
        {
            string mail = (string)Session["AdminUserName"];
            var contact = cm.GetContacts().Count();
            var sendBox = mm.GetMessagesSenbox(mail).Count();
            var inBox = mm.GetMessagesInbox(mail).Count();
            ViewBag.contacts = contact;
            ViewBag.sendBox = sendBox;
            ViewBag.inBox = inBox;
            return PartialView();
        }
    }
}