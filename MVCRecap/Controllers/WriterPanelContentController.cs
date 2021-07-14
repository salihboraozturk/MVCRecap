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
    public class WriterPanelContentController : Controller
    {
        private ContentManager contentManager = new ContentManager(new EfContentDal());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            Context c = new Context();
            string p = (string)Session["WriterMail"];
            var writerID = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentByHeading = contentManager.GetListByWriterID(writerID);
            return View(contentByHeading);
        }
    }
}