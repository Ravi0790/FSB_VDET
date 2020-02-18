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
    public class MachinesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Machines
        public IQueryable<Machine> GetMachines()
        {
            return db.Machines;
        }


        [Route("api/Machines/Location/{id}")]
        public IQueryable<Machine> GetMachinesByLocation(int id)
        {
            return db.Machines.Where(p => p.LocationId == id);
        }

        // GET: api/Machines/5
        [ResponseType(typeof(Machine))]
        public IHttpActionResult GetMachine(int id)
        {
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return NotFound();
            }

            return Ok(machine);
        }

        // PUT: api/Machines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMachine(int id, Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != machine.MachineId)
            {
                return BadRequest();
            }

            db.Entry(machine).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // POST: api/Machines
        [ResponseType(typeof(Machine))]
        public IHttpActionResult PostMachine(Machine machine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Machines.Add(machine);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = machine.MachineId }, machine);
        }

        // DELETE: api/Machines/5
        [ResponseType(typeof(Machine))]
        public IHttpActionResult DeleteMachine(int id)
        {
            Machine machine = db.Machines.Find(id);
            if (machine == null)
            {
                return NotFound();
            }

            db.Machines.Remove(machine);
            db.SaveChanges();

            return Ok(machine);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MachineExists(int id)
        {
            return db.Machines.Count(e => e.MachineId == id) > 0;
        }
    }
}