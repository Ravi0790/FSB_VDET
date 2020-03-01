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
    public class PlantsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Plants
        public IQueryable<Plant> GetPlants()
        {
            return db.Plants;
        }

        [Route("api/Plants/Company/{id}")]
        public IQueryable<Plant> GetPlantsByCompany(int id)
        {
            return db.Plants.Where(p=>p.CompanyId== id && p.Status == true);
        }

        // GET: api/Plants/5
        [ResponseType(typeof(Plant))]
        public IHttpActionResult GetPlant(int id)
        {
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return NotFound();
            }

            return Ok(plant);
        }

        // PUT: api/Plants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlant(int id, Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plant.PlantId)
            {
                return BadRequest();
            }

            db.Entry(plant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
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

        // POST: api/Plants
        [ResponseType(typeof(Plant))]
        public IHttpActionResult PostPlant(Plant plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plants.Add(plant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plant.PlantId }, plant);
        }

        // DELETE: api/Plants/5
        [ResponseType(typeof(Plant))]
        public IHttpActionResult DeletePlant(int id)
        {
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return NotFound();
            }

            db.Plants.Remove(plant);
            db.SaveChanges();

            return Ok(plant);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantExists(int id)
        {
            return db.Plants.Count(e => e.PlantId == id) > 0;
        }
    }
}