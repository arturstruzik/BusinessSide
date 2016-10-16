using BusinessSite.DAL;
using BusinessSite.Models;
using System;
using System.Text;
using System.Web.Mvc;
using System.Linq;
using System.Collections.Generic;
using BusinessSite.Assets;

namespace BusinessSite.Controllers
{
    public class EmailController : Controller
    {
        public SiteContext db = new SiteContext();
        private const string key_encrypt = "ali49ben301ffie";

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
                TempData["IsSuccess"] = "false";
                TempData["ViewBag.Message"] = "Przed wysłaniem poprawnie wypełnij pole z adresem email.";
                return RedirectToAction("Index","Home", model);
            }

            var numList = new List<int>();
            foreach (var c in model.EmailAddress.ToArray())
            {
                numList.Add((int)c);
            }
            var code = Crypto.Encrypt(model.EmailAddress, key_encrypt);
            
            try
            {
                var callbackUrl = Url.Action("Validate", "Calculator", new { emailAddress=model.EmailAddress, code=code }, protocol: Request.Url.Scheme);

                var mailTo = model.EmailAddress;
                var messageContent = "Twój link z jednodniowym dostępem do kalkulatora zysków: " + callbackUrl;
                var mailSubject = "Twój jednodniowy klucz dostępu do kalkulatora zysków.";

                ContactMessageController.SendEmailUsingBuildInCredentials(messageContent, mailTo, mailSubject);
            }
            catch (Exception)
            {
                TempData["IsSuccess"] = "false";
                TempData["ViewBag.Message"] = "Wystąpił błąd podczas wysyłania wiadomości :(";
                return RedirectToAction("Index", "Home");
            }

            TempData["IsSuccess"] = "true";
            TempData["ViewBag.Message"] = "Wiadomość z linkiem dostępu do kalkulatora wysłana pomyślnie :)";
            return RedirectToAction("Index", "Home");
        }
    }
}