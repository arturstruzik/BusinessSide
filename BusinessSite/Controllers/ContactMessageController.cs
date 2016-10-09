using BusinessSite.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;

namespace BusinessSite.Controllers
{
    public class ContactMessageController : Controller
    {
        [HttpPost]
        public ActionResult _PartialPageContact(ContactMessage model)
        {
            var messageContent = "NAME: " + model.Name + " PHONE: " + model.Phone + " QUESTION: " + model.Content;

            MailMessage mail = new MailMessage("info@arturstruzik.pl",
                "info@arturstruzik.pl",
                model.Email + " ask you a question.",
                messageContent);

            SmtpClient smtpClient = new SmtpClient("arturstruzik.nazwa.pl");
            NetworkCredential networkCred = new NetworkCredential("info@arturstruzik.pl", "************");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCred;
            smtpClient.Port = 587; //port dla poczty wychodzącej
            smtpClient.EnableSsl = false;
            try
            {
                smtpClient.Send(mail);
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
        }
    }
}