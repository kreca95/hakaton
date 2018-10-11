using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using hakaton.Models;
namespace hakaton.Controllers
{
    public class AuthController : BaseController
    {
        // GET: Auth
        public ActionResult Registracija()
        {

            return View();
        }
        public ActionResult LogIn()
        {

            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult neovlasteni_pristup()
        {

            return View();
        }
        [HttpPost]
        public JsonResult newLogin(string Email, string Password)
        {
            if (Email != null && Password != null)
            {

                var Clan = db.Clan.Where(x => x.Email == Email && x.Pass == Password).FirstOrDefault();
                if (Clan != null)
                {   
                    FormsAuthentication.SetAuthCookie(Email, true);
                    var CurrClan = db.Clan.Where(u => u.Email == Email).FirstOrDefault();
                    return Json("success", JsonRequestBehavior.AllowGet);

                }
                else
                {
                    FormsAuthentication.SignOut();
                    return Json("fail", JsonRequestBehavior.AllowGet);
                }
            }

            else
            {
                FormsAuthentication.SignOut();
                return Json("fail", JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult Register(string password, string email, string ime, string prezime, string br)
        {
            var korisnik = db.Clan.Any(x => x.Email.ToLower() == email.ToLower());

            if (password != null && email != null)
            {
                if (korisnik == false)
                {
                    var user = new Clan();
                    user.Email = email;
                    user.Pass = password;
                    user.Ime = ime;
                    user.Prezime = prezime;
                    user.Broj_telefona = br;
                    user.UlogaID = 3;
                    db.Clan.Add(user);
                    db.SaveChanges();
                    newLogin(email, password);
                    return Json("success", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("fail", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("fail", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult logOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "profil");
        }
    }
}