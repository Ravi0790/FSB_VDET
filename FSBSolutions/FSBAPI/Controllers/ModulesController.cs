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
    public class ModulesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/Modules
        public IQueryable<Module> GetModules()
        {
            return db.Modules;
        }

        [Route("api/Modules/Machine/{id}")]
        public IQueryable<Module> GetModulesByMachine(int id)
        {
            return db.Modules.Where(p => p.MachineId == id);
        }

        // GET: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult GetModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }

        // PUT: api/Modules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutModule(int id, Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != module.ModuleId)
            {
                return BadRequest();
            }

            db.Entry(module).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
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

        // POST: api/Modules
        [ResponseType(typeof(Module))]
        public IHttpActionResult PostModule(Module module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Modules.Add(module);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = module.ModuleId }, module);
        }

        // DELETE: api/Modules/5
        [ResponseType(typeof(Module))]
        public IHttpActionResult DeleteModule(int id)
        {
            Module module = db.Modules.Find(id);
            if (module == null)
            {
                return NotFound();
            }

            db.Modules.Remove(module);
            db.SaveChanges();

            return Ok(module);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ModuleExists(int id)
        {
            return db.Modules.Count(e => e.ModuleId == id) > 0;
        }
    }
}