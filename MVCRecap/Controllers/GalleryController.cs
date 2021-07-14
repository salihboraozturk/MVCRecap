using BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.EntityFramework;

namespace MVCRecap.Controllers
{
    public class GalleryController : Controller
    {
        private ImageFileManager galleryManager = new ImageFileManager(new EfImageDal());
        // GET: Gallery
        public ActionResult Index()
        {
            var files = galleryManager.GetList();
            return View(files);
        }
    }
}