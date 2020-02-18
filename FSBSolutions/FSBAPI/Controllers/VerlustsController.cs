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
using FSBModel;

namespace FSBAPI.Controllers
{
    public class VerlustsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Verlusts
        public IQueryable<Verlust> GetVerlusts()
        {
            return db.Verlusts;
        }
        [Route("api/Verlusts/UserType/{id}")]
        public IQueryable<Verlust> GetVerlustsByUserType(int id)
        {
            return db.Verlusts.Where(p => p.UserTypeId == id);
        }

        // GET: api/Verlusts/5
        [ResponseType(typeof(Verlust))]
        public IHttpActionResult GetVerlust(int id)
        {
            Verlust verlust = db.Verlusts.Find(id);
            if (verlust == null)
            {
                return NotFound();
            }

            return Ok(verlust);
        }

        // PUT: api/Verlusts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVerlust(int id, Verlust verlust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != verlust.VerlustId)
            {
                return BadRequest();
            }

            db.Entry(verlust).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerlustExists(id))
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

        // POST: api/Verlusts
        [ResponseType(typeof(Verlust))]
        public IHttpActionResult PostVerlust(Verlust verlust)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Verlusts.Add(verlust);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = verlust.VerlustId }, verlust);
        }

        // DELETE: api/Verlusts/5
        [ResponseType(typeof(Verlust))]
        public IHttpActionResult DeleteVerlust(int id)
        {
            Verlust verlust = db.Verlusts.Find(id);
            if (verlust == null)
            {
                return NotFound();
            }

            db.Verlusts.Remove(verlust);
            db.SaveChanges();

            return Ok(verlust);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VerlustExists(int id)
        {
            return db.Verlusts.Count(e => e.VerlustId == id) > 0;
        }
    }
}