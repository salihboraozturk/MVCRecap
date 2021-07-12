using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;

namespace MVCRecap.Controllers
{
    public class StatisticController : Controller
    {
        private CategoryManager cm = new CategoryManager(new EfCategoryDal());
        private HeadingManager hd = new HeadingManager(new EfHeadingDal());
        private WriterManager wr = new WriterManager(new EfWriterDal());

        // GET: Statistic
        public ActionResult Index()
        {
            ViewData["CategoryCount"] = cm.GetList().Count();
            ViewData["HeadingSoftwareCount"] = hd.GetAllByCategoryID(14).Count();
            ViewData["WriterInA"] = wr.GetAllWriterInA().Count();
            ViewData["TrueMinusFalse"] = cm.GetAllCategoryStatusTrue().Count()- cm.GetAllCategoryStatusFalse().Count();
            ViewData["A"] = cm.GetByID(hd.GetTopBusinessCategories().CategoryID).CategoryName;
                ;
            return View();
        }


    }
}