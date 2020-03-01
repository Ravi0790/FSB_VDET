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
    public class VerlustartsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Verlustarts
        public IQueryable<Verlustart> GetVerlustarts()
        {
            return db.Verlustarts;
        }


        [Route("api/Verlustarts/UserType/{id}")]
        public IQueryable<Verlustart> GetVerlustartsByUserType(int id)
        {
            return db.Verlustarts.Where(p => p.UserTypeId == id && p.Status == true);
        }


        // GET: api/Verlustarts/5
        [ResponseType(typeof(Verlustart))]
        public IHttpActionResult GetVerlustart(int id)
        {
            Verlustart verlustart = db.Verlustarts.Find(id);
            if (verlustart == null)
            {
                return NotFound();
            }

            return Ok(verlustart);
        }

        // PUT: api/Verlustarts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVerlustart(int id, Verlustart verlustart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != verlustart.VerlustartId)
            {
                return BadRequest();
            }

            db.Entry(verlustart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VerlustartExists(id))
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

        // POST: api/Verlustarts
        [ResponseType(typeof(Verlustart))]
        public IHttpActionResult PostVerlustart(Verlustart verlustart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Verlustarts.Add(verlustart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = verlustart.VerlustartId }, verlustart);
        }

        // DELETE: api/Verlustarts/5
        [ResponseType(typeof(Verlustart))]
        public IHttpActionResult DeleteVerlustart(int id)
        {
            Verlustart verlustart = db.Verlustarts.Find(id);
            if (verlustart == null)
            {
                return NotFound();
            }

            db.Verlustarts.Remove(verlustart);
            db.SaveChanges();

            return Ok(verlustart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VerlustartExists(int id)
        {
            return db.Verlustarts.Count(e => e.VerlustartId == id) > 0;
        }
    }
}