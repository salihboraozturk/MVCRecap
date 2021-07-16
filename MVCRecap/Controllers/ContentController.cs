using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;

namespace MVCRecap.Controllers
{
    public class ContentController : Controller
    {
        private ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetListFilter(p);
            //var values = c.Contents.ToList();
            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentByHeading = cm.GetListByHeadingID(id);
            return View(contentByHeading);
        }
    }
}