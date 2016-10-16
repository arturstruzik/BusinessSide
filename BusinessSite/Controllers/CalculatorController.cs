using BusinessSite.DAL;
using BusinessSite.Models;
using System.Web.Mvc;
using System.Linq;
using System;
using BusinessSite.Assets;

namespace BusinessSite.Controllers
{
    public class CalculatorController : Controller
    {
        public SiteContext db = new SiteContext();
        private const string key_decrypt = "ali49ben301ffie";

        [HttpGet]
        public ActionResult Validate(string emailAddress, string code)
        {

            if ((emailAddress == Crypto.Decrypt(code, key_decrypt)))
            {
                if (db.Emails.Any(m => m.EmailAddress == emailAddress))
                {
                    if (db.Emails.Where(m => m.EmailAddress == emailAddress).First().CalcAccessDateID == null)
                    {
                        db.Emails.Where(m => m.EmailAddress == emailAddress).First().CalcAccessDate 
                            = new CalcAccessDate() { DateTo = DateTime.Now.AddDays(1), DateIsSet = true };
                        db.SaveChanges();
                    }

                    if (db.Emails.Where(m => m.EmailAddress == emailAddress)
                        .First().CalcAccessDate.DateTo > DateTime.Now)
                    {
                        TempData["IsSuccess"] = "true";
                        TempData["ViewBag.Message"] = "Witaj " + emailAddress + ".";
                        return View("Index", db.Emails.Where(m => m.EmailAddress == emailAddress)
                        .First().CalcAccessDate);
                    }
                    else
                    {
                        TempData["IsSuccess"] = "false";
                        TempData["ViewBag.Message"] = "Wykorzystałeś już swój jednodniowy dostęp do kalkulatora :(";
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    db.Emails.Add(new Email() { EmailAddress = emailAddress, 
                        CalcAccessDate = new CalcAccessDate() { DateTo = DateTime.Now.AddDays(1), DateIsSet = true } });
                    db.SaveChanges();

                    TempData["IsSuccess"] = "true";
                    TempData["ViewBag.Message"] = "Witaj " + emailAddress + ".";
                    return View("Index", db.Emails.Where(m => m.EmailAddress == emailAddress)
                        .First().CalcAccessDate);
                }
            }
            else 
            {
                TempData["IsSuccess"] = "false";
                TempData["ViewBag.Message"] = "Niewłaściwe dane. Link jest nieaktywny :(";
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult Validate()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index(CalcAccessDate model)
        {
            if (model.DateTo < DateTime.Now)
            {
                TempData["IsSuccess"] = "false";
                TempData["ViewBag.Message"] = "Niestety okres ważności dostępu minął :( Zarejestruj się dla nielimitowanego dostępu :)";
            }
            else
            {
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}