using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MVCRecap.Controllers
{
    public class WriterPanelController : Controller
    {
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
         private CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
         Context c = new Context();
        // GET: WriterPanel
        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
           
            string p = (string) Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetListByWriter(writerID);
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
        public ActionResult DeleteHeading(int headingID)
        {

            var deletedValue = headingManager.GetByID(headingID);
            deletedValue.HeadingStatus = false;
            headingManager.HeadingDelete(deletedValue);
            return RedirectToAction("MyHeading");
        }
    }
}