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
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private ContentManager contentManager = new ContentManager(new EfContentDal());
        private HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        // GET: Default
        public ActionResult Headings()
        {
            var headingList = headingManager.GetList();
            return View(headingList);
        }
        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetListByHeadingID(id);
            return PartialView(contentList);
        }
    }
}