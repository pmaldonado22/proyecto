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
    public class PansController : ApiController
    {
        private panaderiasModelo db = new panaderiasModelo();

        // GET: api/Pans
        public IQueryable<Pans> GetPans()
        {
            return db.Pans;
        }

        // GET: api/Pans/5
        [ResponseType(typeof(Pans))]
        public IHttpActionResult GetPans(int id)
        {
            Pans pans = db.Pans.Find(id);
            if (pans == null)
            {
                return NotFound();
            }

            return Ok(pans);
        }

        // PUT: api/Pans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPans(int id, Pans pans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pans.PanID)
            {
                return BadRequest();
            }

            db.Entry(pans).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PansExists(id))
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

        // POST: api/Pans
        [ResponseType(typeof(Pans))]
        public IHttpActionResult PostPans(Pans pans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pans.Add(pans);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pans.PanID }, pans);
        }

        // DELETE: api/Pans/5
        [ResponseType(typeof(Pans))]
        public IHttpActionResult DeletePans(int id)
        {
            Pans pans = db.Pans.Find(id);
            if (pans == null)
            {
                return NotFound();
            }

            db.Pans.Remove(pans);
            db.SaveChanges();

            return Ok(pans);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PansExists(int id)
        {
            return db.Pans.Count(e => e.PanID == id) > 0;
        }
    }
}