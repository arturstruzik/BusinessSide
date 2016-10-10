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
            try
            {
                var messageContent = "NAME: " + model.Name + " PHONE: " + model.Phone + " QUESTION: " + model.Content;
                var mailTo = "info@arturstruzik.pl";
                var mailSubject = model.Email + " ask you a question.";

                SendEmailUsingBuildInCredentials(messageContent, mailTo, mailSubject);
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

        public static void SendEmailUsingBuildInCredentials(string messageContent, string mailTo, string mailSubject)
        {
            MailMessage mail = new MailMessage("info@arturstruzik.pl", mailTo, mailSubject, messageContent);
            SmtpClient smtpClient = new SmtpClient("arturstruzik.nazwa.pl");
            NetworkCredential networkCred = new NetworkCredential("info@arturstruzik.pl", "Amnezja18mx3");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = networkCred;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = false;
            smtpClient.Send(mail);
        }
    }
}