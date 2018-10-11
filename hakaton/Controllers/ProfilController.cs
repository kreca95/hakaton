using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton;
using hakaton.Models;

namespace hakaton.Controllers
{
    public class ProfilController : BaseController
    {
        // GET: Profil
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login","auth");
            }
            Clan naci = db.Clan.FirstOrDefault(x => x.Email == User.Identity.Name);
            //var user = db.Clan.Find(naci.ID).Rezervacija.Select(x => x.Knjiga);
            var user = db.Clan.Find(naci.ID).Rezervacija.OrderByDescending(x=>x.Datum);
            ViewBag.Knjiga = user;
            ViewBag.ID = naci.ID;
            return View();
        }

        public ActionResult MojiPodaci()
        {
            Clan user = db.Clan.FirstOrDefault(x => x.Email == User.Identity.Name);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult MojiPodaci(Clan clan)
        {
            var korisnik = db.Clan.Find(clan.ID);
            if (ModelState.IsValid)
            {
                korisnik.Ime = clan.Ime;
                korisnik.Prezime = clan.Prezime;
                korisnik.Pass = clan.Pass;
                korisnik.Adresa = clan.Adresa;
                korisnik.Broj_telefona = clan.Broj_telefona;
                korisnik.Datum_Rodjenja = clan.Datum_Rodjenja;
                korisnik.Email = clan.Email;
            }

            db.SaveChanges();

            return View();
        }

    }
}