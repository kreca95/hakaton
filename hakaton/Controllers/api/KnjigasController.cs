using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using hakaton.Models;

namespace hakaton.Controllers.api
{
    public class KnjigasController : ApiController
    {
        private knjiznicaEntities db = new knjiznicaEntities();

        // GET: api/Knjigas
        public IQueryable<Knjiga> GetKnjiga()
        {
            return db.Knjiga;
        }

        // GET: api/Knjigas/5
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult GetKnjiga(int id)
        {
            Knjiga knjiga = db.Knjiga.Find(id);
            if (knjiga == null)
            {
                return NotFound();
            }

            return Ok(knjiga);
        }

        // PUT: api/Knjigas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnjiga(int id, Knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knjiga.ID)
            {
                return BadRequest();
            }

            db.Entry(knjiga).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnjigaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Knjigas
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult PostKnjiga(Knjiga knjiga)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Knjiga.Add(knjiga);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = knjiga.ID }, knjiga);
        }

        // DELETE: api/Knjigas/5
        [ResponseType(typeof(Knjiga))]
        public IHttpActionResult DeleteKnjiga(int id)
        {
            Knjiga knjiga = db.Knjiga.Find(id);
            if (knjiga == null)
            {
                //return NotFound();
            }

            db.Knjiga.Remove(knjiga);
            db.SaveChanges();

            return Ok(knjiga);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KnjigaExists(int id)
        {
            return db.Knjiga.Count(e => e.ID == id) > 0;
        }
    }
}