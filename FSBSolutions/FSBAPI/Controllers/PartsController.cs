﻿using System;
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
    public class PartsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Parts
        public IQueryable<Part> GetParts()
        {
            return db.Parts;
        }

        [Route("api/Parts/Component/{id}")]
        public IQueryable<Part> GetPartsByComponent(int id)
        {
            return db.Parts.Where(p => p.ComponentId == id && p.Status == true).OrderBy(x=>x.PartName);
        }

        // GET: api/Parts/5
        [ResponseType(typeof(Part))]
        public IHttpActionResult GetPart(int id)
        {
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return NotFound();
            }

            return Ok(part);
        }

        // PUT: api/Parts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPart(int id, Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != part.PartId)
            {
                return BadRequest();
            }

            db.Entry(part).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
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

        // POST: api/Parts
        [ResponseType(typeof(Part))]
        public IHttpActionResult PostPart(Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parts.Add(part);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = part.PartId }, part);
        }

        // DELETE: api/Parts/5
        [ResponseType(typeof(Part))]
        public IHttpActionResult DeletePart(int id)
        {
            Part part = db.Parts.Find(id);
            if (part == null)
            {
                return NotFound();
            }

            db.Parts.Remove(part);
            db.SaveChanges();

            return Ok(part);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartExists(int id)
        {
            return db.Parts.Count(e => e.PartId == id) > 0;
        }
    }
}