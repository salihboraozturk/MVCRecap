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
    public class WriterPanelContentController : Controller
    {
        private ContentManager contentManager = new ContentManager(new EfContentDal());
        Context c = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            string p = (string)Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentByHeading = contentManager.GetListByWriterID(writerID);
            return View(contentByHeading);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            content.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            var p = (string) Session["WriterMail"];
            int id=c.Writers.Where(x => x.WriterMail ==p).Select(y => y.WriterID).FirstOrDefault();
            content.WriterID = id;
            content.ContentStatus = true;
            contentManager.ContentAddBL(content);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}