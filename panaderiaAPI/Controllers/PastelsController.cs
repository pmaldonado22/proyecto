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
using panaderiaAPI.Models;

namespace panaderiaAPI.Controllers
{
    public class PastelsController : ApiController
    {
        private panaderiasModelo db = new panaderiasModelo();

        // GET: api/Pastels
        public IQueryable<Pastels> GetPastels()
        {
            return db.Pastels;
        }

        // GET: api/Pastels/5
        [ResponseType(typeof(Pastels))]
        public IHttpActionResult GetPastels(int id)
        {
            Pastels pastels = db.Pastels.Find(id);
            if (pastels == null)
            {
                return NotFound();
            }

            return Ok(pastels);
        }

        // PUT: api/Pastels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPastels(int id, Pastels pastels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pastels.PastelID)
            {
                return BadRequest();
            }

            db.Entry(pastels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PastelsExists(id))
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

        // POST: api/Pastels
        [ResponseType(typeof(Pastels))]
        public IHttpActionResult PostPastels(Pastels pastels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pastels.Add(pastels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pastels.PastelID }, pastels);
        }

        // DELETE: api/Pastels/5
        [ResponseType(typeof(Pastels))]
        public IHttpActionResult DeletePastels(int id)
        {
            Pastels pastels = db.Pastels.Find(id);
            if (pastels == null)
            {
                return NotFound();
            }

            db.Pastels.Remove(pastels);
            db.SaveChanges();

            return Ok(pastels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PastelsExists(int id)
        {
            return db.Pastels.Count(e => e.PastelID == id) > 0;
        }
    }
}