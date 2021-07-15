using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;

namespace MVCRecap.Controllers
{
    public class WriterPanelController : Controller
    {
        private WriterValidator validationRules = new WriterValidator();
        private WriterManager writerManager = new WriterManager(new EfWriterDal());
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
         private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
         Context c = new Context();
        // GET: WriterPanel
        [HttpGet]
        public ActionResult WriterProfile()
        {
            string p = (string)Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManager.GetByID(writerID);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            ValidationResult results = validationRules.Validate(writer);
            if (results.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("WriterProfile");
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
        public ActionResult MyHeading()
        {
           
            string p = (string) Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerID);
            return View(values);
        }
        public ActionResult AllHeading(int p=1)
        {
            var values = headingManager.GetList().ToPagedList(p,3);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
           
            ViewBag.vlc = valueCategory;
            return View();
           
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string p = (string)Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerID;
            heading.HeadingStatus = true;
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = headingManager.GetByID(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {

            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {

            var deletedValue = headingManager.GetByID(id);
            headingManager.HeadingDelete(deletedValue);
            return RedirectToAction("MyHeading");
        }
    }
}