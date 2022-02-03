using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Proje_Kampi.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
        SkillManager sm = new SkillManager(new EfSkillDal());

        public ActionResult Index()
        {
            var skills = sm.GetSkills();
            return View(skills);
        }
    }
}