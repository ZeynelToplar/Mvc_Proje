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
    public class AdminCategoryController : Controller
    {
        // GET: AdminCategory
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles ="B")]
        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetCategories();
            return View(categoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);
            if (results.IsValid)
            {
                categoryManager.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var category = categoryManager.GetById(id);
            categoryManager.DeleteCategory(category);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var category = categoryManager.GetById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category c)
        {
            categoryManager.UpdateCategory(c);
            return RedirectToAction("Index");
        }
    }
}