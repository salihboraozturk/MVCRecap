using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MVCRecap.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private CategoryManager cm = new CategoryManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryValues = cm.GetAllBL();
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
            cm.CategoryAddBL(category);
            return RedirectToAction("GetCategoryList");
        }
    }
}