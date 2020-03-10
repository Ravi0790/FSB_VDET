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
    public class WasteDetailsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/WasteDetails
        public IQueryable<WasteDetail> GetWasteDetails()
        {
            return db.WasteDetails;
        }

        [HttpGet]
        [Route("api/WasteDetails/Order/UserType/{orderid}/{usertypeid}")]
        public IQueryable<WasteDetail> GetWasteDetailsByOrderId(int orderid,int usertypeid)
        {
            return db.WasteDetails.Where(x=>x.OrderId==orderid && x.UserTypeId==usertypeid).OrderByDescending(x=>x.WasteId);
        }

        // GET: api/WasteDetails/5
        [ResponseType(typeof(WasteDetail))]
        public IHttpActionResult GetWasteDetail(int id)
        {
            WasteDetail wasteDetail = db.WasteDetails.Find(id);
            if (wasteDetail == null)
            {
                return NotFound();
            }

            return Ok(wasteDetail);
        }

        // PUT: api/WasteDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWasteDetail(int id, WasteDetail wasteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wasteDetail.WasteId)
            {
                return BadRequest();
            }

            db.Entry(wasteDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WasteDetailExists(id))
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

        // POST: api/WasteDetails
        [ResponseType(typeof(WasteDetail))]
        public IHttpActionResult PostWasteDetail(WasteDetail wasteDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WasteDetails.Add(wasteDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wasteDetail.WasteId }, wasteDetail);
        }

        // DELETE: api/WasteDetails/5
        [ResponseType(typeof(WasteDetail))]
        public IHttpActionResult DeleteWasteDetail(int id)
        {
            WasteDetail wasteDetail = db.WasteDetails.Find(id);
            if (wasteDetail == null)
            {
                return NotFound();
            }

            db.WasteDetails.Remove(wasteDetail);
            db.SaveChanges();

            return Ok(wasteDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WasteDetailExists(int id)
        {
            return db.WasteDetails.Count(e => e.WasteId == id) > 0;
        }
    }
}