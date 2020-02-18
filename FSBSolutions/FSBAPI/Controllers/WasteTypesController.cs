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
    public class WasteTypesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/WasteTypes
        public IQueryable<WasteType> GetWasteTypes()
        {
            return db.WasteTypes;
        }

        [Route("api/WasteTypes/UserType/{id}")]
        public IQueryable<WasteType> GetWasteTypesByUserType(int id)
        {
            return db.WasteTypes.Where(p => p.UserTypeId == id);
        }

        // GET: api/WasteTypes/5
        [ResponseType(typeof(WasteType))]
        public IHttpActionResult GetWasteType(int id)
        {
            WasteType wasteType = db.WasteTypes.Find(id);
            if (wasteType == null)
            {
                return NotFound();
            }

            return Ok(wasteType);
        }

        // PUT: api/WasteTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWasteType(int id, WasteType wasteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wasteType.WasteTypeId)
            {
                return BadRequest();
            }

            db.Entry(wasteType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteTypeExists(id))
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

        // POST: api/WasteTypes
        [ResponseType(typeof(WasteType))]
        public IHttpActionResult PostWasteType(WasteType wasteType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WasteTypes.Add(wasteType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wasteType.WasteTypeId }, wasteType);
        }

        // DELETE: api/WasteTypes/5
        [ResponseType(typeof(WasteType))]
        public IHttpActionResult DeleteWasteType(int id)
        {
            WasteType wasteType = db.WasteTypes.Find(id);
            if (wasteType == null)
            {
                return NotFound();
            }

            db.WasteTypes.Remove(wasteType);
            db.SaveChanges();

            return Ok(wasteType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WasteTypeExists(int id)
        {
            return db.WasteTypes.Count(e => e.WasteTypeId == id) > 0;
        }
    }
}