using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;

namespace MVCRecap.Controllers
{
    public class ContactController : Controller
    {
        private ContactManager contactManager = new ContactManager(new EfContactDal());

        private ContactValidator cv = new ContactValidator();
        // GET: Contact
        public ActionResult Index()
        {
            var ContactValues = contactManager.GetList();
            return View(ContactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetByID(id);
            return View(contactValues);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
    }
}