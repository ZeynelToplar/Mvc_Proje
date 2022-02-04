using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class MessageController : Controller
    {
        // GET: Messageontroller
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            var messages = mm.GetMessagesInbox();
            var unreadCount = mm.GetUnreadMessage();
            ViewBag.unreadCount = unreadCount.Count();
            return View(messages);
        }
        public ActionResult GetMessageDetail(int id)
        {
            var message = mm.GetById(id);
            // <-- Tıklandığında mesajı okundu olarak güncelleme
            message.UnRead = false;
            mm.UpdateMessage(message);
            // -->
            return View(message);
        }
        public ActionResult SendBox()
        {
            var messages = mm.GetMessagesSenbox();
            return View(messages);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message, string submitButton)
        {
            switch (submitButton)
            {
                case "Taslaklara Kaydet":
                    return AddDraft(message);
                case "Gönder":
                    ValidationResult results = messageValidator.Validate(message);
                    if (results.IsValid)
                    {
                        message.MessageDate = DateTime.Now;

                        mm.AddMessage(message);
                        return RedirectToAction("SendBox");
                    }
                    else
                    {
                        foreach (var item in results.Errors)
                        {
                            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                        }
                    }
                    break;
            }
            return View();
        }
        [HttpPost]
        public ActionResult AddDraft(Message draft)
        {
            draft.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            draft.IsDraft = true;
            mm.AddMessage(draft);
            return RedirectToAction("AddDraft");
        }
        public ActionResult UnRead()
        {
            var messages = mm.GetUnreadMessage();
            return View(messages);
        }
    }
}