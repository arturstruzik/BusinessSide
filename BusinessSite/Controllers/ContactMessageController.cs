using BusinessSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusinessSite.Controllers
{
    public class ContactMessageController : Controller
    {
        [HttpPost]
        public ActionResult _PartialPageContact(ContactMessage model)
        {
            TempData["IsSuccess"] = "true";
            TempData["ViewBag.Message"] = "Message send successfully";

            return RedirectToAction("Index", "Home");
        }


    }
}