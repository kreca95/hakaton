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
    [Authorize(Roles = "Admin, Knjiznicar")]

    public class ClansController : BaseController
    {

        // GET: Clans
        [Authorize(Roles=("Admin, Knjiznicar"))]
        public ActionResult Naslovna()
        {

            return View();
        }
        public ActionResult MojaIznajmljivanja()
        {

            return View();
        }
        public ActionResult Index()
        {
            return View(db.Clan.ToList());
        }
        public ActionResult Profil()
        {
            var korisnik = HttpContext.User.Identity.Name;
            var ja = db.Clan.Where(x => x.Email == korisnik);
            return View();
        }
        // GET: Clans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = db.Clan.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // GET: Clans/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Clan clan)
        {
            if (ModelState.IsValid)
            {
                db.Clan.Add(clan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Uloga = new SelectList(db.Role, "ID", "Naziv");
            return View(clan);
        }

        // GET: Clans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = db.Clan.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clan clan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clan);
        }

        // GET: Clans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clan clan = db.Clan.Find(id);
            if (clan == null)
            {
                return HttpNotFound();
            }
            return View(clan);
        }

        // POST: Clans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clan clan = db.Clan.Find(id);
            db.Clan.Remove(clan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
