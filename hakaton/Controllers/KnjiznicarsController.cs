using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;

namespace hakaton.Controllers
{
    public class KnjiznicarsController : BaseController
    {

        public ActionResult Index()
        {
            return View(db.Knjiznicar.ToList());
        }

        public ActionResult Evidencija()
        {
            //            string query = @"select * from Rezervacija r,Clan c,Knjiga k
            //where r.Clan_ID=c.ID
            //and r.Knjiga_ID=k.id";

            //            using (knjiznicaEntities db = new knjiznicaEntities())
            //            {
            //                var list = db.Database.SqlQuery<Rezervacija>(query);
            //                ViewBag.Evidencija = list.ToList();
            //            }
            var a = db.Rezervacija.ToList();
            ViewBag.Evidencija = a;
            return View();
        }

        public ActionResult Rezervacija()
        {
            var dostupneKnjige = db.Knjiga.Where(x => x.Dostupnost == true).ToList();
            ViewBag.Knjige = dostupneKnjige;
            return View();
        }

        public JsonResult RezervacijaJSON(int id, string nazivKnjige)
        {
            Clan korisnik = db.Clan.Find(id);
            Knjiga knjiga = db.Knjiga.FirstOrDefault(x => x.Naziv == nazivKnjige);

            Rezervacija rezervacija = new Rezervacija();

            rezervacija.Clan_ID = korisnik.ID;
            rezervacija.Knjiga_ID = knjiga.ID;
            rezervacija.Datum = DateTime.Now.ToShortDateString();
            db.Rezervacija.Add(rezervacija);
            db.SaveChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public JsonResult RezervacijaKorisnikJSON(string nazivKnjige)
        {

            Clan logiraniKorisnik = db.Clan.FirstOrDefault(x => x.Email == User.Identity.Name);
            Knjiga knjiga = db.Knjiga.FirstOrDefault(x => x.Naziv == nazivKnjige);
            Rezervacija rezervacija = new Rezervacija();

            rezervacija.Knjiga_ID = knjiga.ID;
            rezervacija.Datum = DateTime.Now.ToShortDateString();
            db.Rezervacija.Add(rezervacija);
            db.SaveChanges();

            return Json("success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznicar knjiznicar = db.Knjiznicar.Find(id);
            if (knjiznicar == null)
            {
                return HttpNotFound();
            }
            return View(knjiznicar);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Knjiznicar knjiznicar)
        {
            if (ModelState.IsValid)
            {
                db.Knjiznicar.Add(knjiznicar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiznicar);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznicar knjiznicar = db.Knjiznicar.Find(id);
            if (knjiznicar == null)
            {
                return HttpNotFound();
            }
            return View(knjiznicar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Knjiznicar knjiznicar)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiznicar).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knjiznicar);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiznicar knjiznicar = db.Knjiznicar.Find(id);
            if (knjiznicar == null)
            {
                return HttpNotFound();
            }
            return View(knjiznicar);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjiznicar knjiznicar = db.Knjiznicar.Find(id);
            db.Knjiznicar.Remove(knjiznicar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
