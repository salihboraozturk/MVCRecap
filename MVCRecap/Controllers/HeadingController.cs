using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MVCRecap.Controllers
{
    public class HeadingController : Controller
    {
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        private WriterManager writerManager = new WriterManager(new EfWriterDal());
       
        // GET: Heading
        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                select new SelectListItem
                {
                    Text =x.CategoryName,
                    Value = x.CategoryID.ToString()
                }).ToList();
            List<SelectListItem> valueWriter = (from x in writerManager.GetList()
                select new SelectListItem
                {
                    Text = x.WriterName+" "+x.WriterSurname,
                    Value = x.WriterID.ToString()
                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAddBL(heading);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int? headingID)
        {

            var deletedValue = headingManager.GetByID((int)headingID);
            deletedValue.HeadingStatus = false;
            headingManager.HeadingUpdate(deletedValue);
            return RedirectToAction("Index");
        }

    }
}