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
    public class SucursalsController : ApiController
    {
        private panaderiasModelo db = new panaderiasModelo();

        // GET: api/Sucursals
        public IQueryable<Sucursals> GetSucursals()
        {
            return db.Sucursals;
        }

        // GET: api/Sucursals/5
        [ResponseType(typeof(Sucursals))]
        public IHttpActionResult GetSucursals(int id)
        {
            Sucursals sucursals = db.Sucursals.Find(id);
            if (sucursals == null)
            {
                return NotFound();
            }

            return Ok(sucursals);
        }

        // PUT: api/Sucursals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursals(int id, Sucursals sucursals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursals.SucursalID)
            {
                return BadRequest();
            }

            db.Entry(sucursals).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalsExists(id))
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

        // POST: api/Sucursals
        [ResponseType(typeof(Sucursals))]
        public IHttpActionResult PostSucursals(Sucursals sucursals)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursals.Add(sucursals);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sucursals.SucursalID }, sucursals);
        }

        // DELETE: api/Sucursals/5
        [ResponseType(typeof(Sucursals))]
        public IHttpActionResult DeleteSucursals(int id)
        {
            Sucursals sucursals = db.Sucursals.Find(id);
            if (sucursals == null)
            {
                return NotFound();
            }

            db.Sucursals.Remove(sucursals);
            db.SaveChanges();

            return Ok(sucursals);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalsExists(int id)
        {
            return db.Sucursals.Count(e => e.SucursalID == id) > 0;
        }
    }
}