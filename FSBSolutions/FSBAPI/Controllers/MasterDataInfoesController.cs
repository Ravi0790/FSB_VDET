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
    public class MasterDataInfoesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/MasterDataInfoes
        public IQueryable<MasterDataInfo> GetMasterDataInfos()
        {
            return db.MasterDataInfos;
        }

        // GET: api/MasterDataInfoes/5
        [ResponseType(typeof(MasterDataInfo))]
        public IHttpActionResult GetMasterDataInfo(int id)
        {
            MasterDataInfo masterDataInfo = db.MasterDataInfos.Find(id);
            if (masterDataInfo == null)
            {
                return NotFound();
            }

            return Ok(masterDataInfo);
        }

        // PUT: api/MasterDataInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMasterDataInfo(int id, MasterDataInfo masterDataInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != masterDataInfo.Id)
            {
                return BadRequest();
            }

            db.Entry(masterDataInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterDataInfoExists(id))
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

        // POST: api/MasterDataInfoes
        [ResponseType(typeof(MasterDataInfo))]
        public IHttpActionResult PostMasterDataInfo(MasterDataInfo masterDataInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MasterDataInfos.Add(masterDataInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = masterDataInfo.Id }, masterDataInfo);
        }

        // DELETE: api/MasterDataInfoes/5
        [ResponseType(typeof(MasterDataInfo))]
        public IHttpActionResult DeleteMasterDataInfo(int id)
        {
            MasterDataInfo masterDataInfo = db.MasterDataInfos.Find(id);
            if (masterDataInfo == null)
            {
                return NotFound();
            }

            db.MasterDataInfos.Remove(masterDataInfo);
            db.SaveChanges();

            return Ok(masterDataInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MasterDataInfoExists(int id)
        {
            return db.MasterDataInfos.Count(e => e.Id == id) > 0;
        }
    }
}