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
            return JavaScript("alert('Some message')");
        }


    }
}