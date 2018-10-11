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
    [Authorize(Roles =("Admin, Knjiznicar"))]
    public class KnjigasController : BaseController
    {

        // GET: Knjigas
        public ActionResult Index()
        {
            
            return View(db.Knjiga.ToList());
        }

        // GET: Knjigas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjiga.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // GET: Knjigas/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Knjiga.Add(knjiga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(knjiga);
        }

        // GET: Knjigas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjiga.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Knjiga knjiga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knjiga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(knjiga);
        }

        // GET: Knjigas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Knjiga knjiga = db.Knjiga.Find(id);
            if (knjiga == null)
            {
                return HttpNotFound();
            }
            return View(knjiga);
        }

        // POST: Knjigas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Knjiga knjiga = db.Knjiga.Find(id);
            db.Knjiga.Remove(knjiga);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
