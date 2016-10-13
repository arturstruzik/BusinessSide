using BusinessSite.Models;
using System;
using System.Web.Mvc;

namespace BusinessSite.Controllers
{
    public class EmailController : Controller
    {
        // GET: Email
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(Email model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var mailTo = model.EmailAddress;
                var messageContent = "";
                var mailSubject = "Twój jednorazowy klucz dostępu do kalkulatora zysków.";

                ContactMessageController.SendEmailUsingBuildInCredentials(messageContent, mailTo, mailSubject);
            }
            catch (Exception)
            {
                TempData["IsSuccess"] = "false";
                TempData["ViewBag.Message"] = "Wystąpił błąd podczas wysyłania wiadomości :(";
                return RedirectToAction("Index", "Home");
            }

            TempData["IsSuccess"] = "true";
            TempData["ViewBag.Message"] = "Wiadomość wysłana pomyślnie :)";
            return RedirectToAction("Index", "Home");

            return View();
        }
    }
}