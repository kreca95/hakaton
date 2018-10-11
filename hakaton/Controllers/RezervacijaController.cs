using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;
using hakaton;

namespace hakaton.Controllers
{
    [Authorize]
    public class RezervacijaController : BaseController
    {
        // GET: Rezervacija
        public ActionResult Index()
        {
            ViewBag.Knjige = db.Knjiga.Where(x => x.Dostupnost == true).ToList();
            return View();
        }

        public JsonResult RezervacijaKorisnikJSON(string nazivKnjige)
        {

            Clan logiraniKorisnik = db.Clan.FirstOrDefault(x => x.Email == User.Identity.Name);
            Knjiga knjiga = db.Knjiga.FirstOrDefault(x => x.Naziv == nazivKnjige);
            Rezervacija rezervacija = new Rezervacija();

            rezervacija.Clan_ID = logiraniKorisnik.ID;
            rezervacija.Knjiga_ID = knjiga.ID;
            rezervacija.Datum = DateTime.Now.ToShortDateString();
            db.Rezervacija.Add(rezervacija);
            db.SaveChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }
    }
}