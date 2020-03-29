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
using FSBAPI.Models;

namespace FSBAPI.Controllers
{
    public class OrderVolumesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/OrderVolumes
        public IQueryable<OrderProducedVolume> GetOrderProducedVolumes()
        {
            return db.OrderProducedVolumes;
        }



        // GET: api/OrderVolumes/5
        [ResponseType(typeof(OrderProducedVolume))]
        public IHttpActionResult GetOrderProducedVolume(int id)
        {
            OrderProducedVolume orderProducedVolume = db.OrderProducedVolumes.Find(id);
            if (orderProducedVolume == null)
            {
                return NotFound();
            }

            return Ok(orderProducedVolume);
        }

        
        [HttpGet]
        [Route("api/ordervolumes/order/{orderid}")]
        public IList<OrderProducedVolume> GetOrderVolumeByOrder(int orderid)
        {
            IList<OrderProducedVolume> orderProducedVolume = db.OrderProducedVolumes
                                                            .Where(x=>x.OrderId==orderid)
                                                            .OrderBy(x=>x.ProducedVolumeId)
                                                            .ToList();


            return orderProducedVolume;
        }



        [HttpPost]
        [Route("api/ordervolumes/update")]
        public string UpdateOrderProducedVolume(OrderProducedVolume producedvolume)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var returnval = "";

            var volumeobj = db.OrderProducedVolumes.SingleOrDefault(x => x.ProducedVolumeId == producedvolume.ProducedVolumeId);

            
            volumeobj.Dollies = producedvolume.Dollies;
            volumeobj.Pieces = producedvolume.Pieces;
            volumeobj.Korbe = producedvolume.Korbe;
            volumeobj.GeplanteMenge = producedvolume.GeplanteMenge;
            volumeobj.Efficiency = producedvolume.Efficiency;
            volumeobj.Duration = producedvolume.Duration;



            try
            {
                db.SaveChanges();

                db.OrderProducedVolumes
                    .Where(x => x.OrderId == producedvolume.OrderId).ToList()
                    .ForEach(x => x.DisplayRowId = producedvolume.DisplayRowId);
                db.SaveChanges();


                returnval = "volume updated";
            }
            catch (Exception ex)
            {
                returnval = ex.Message.ToString();
            }

            return returnval;
        }

        // POST: api/OrderVolumes
        [ResponseType(typeof(OrderProducedVolume))]
        public IHttpActionResult PostOrderProducedVolume(OrderProducedVolume orderProducedVolume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderProducedVolumes.Add(orderProducedVolume);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderProducedVolume.ProducedVolumeId }, orderProducedVolume);
        }

        
        [HttpPost]
        [Route("api/ordervolumes/all")]
        public string PostOrderProducedVolume(OrderVolumeList OrderVolumeList)
        {

            string result = "no data found";
            try
            {
                foreach (var item in OrderVolumeList.OrderVolume)
                {
                    db.OrderProducedVolumes.Add(item);
                    db.SaveChanges();
                }

                result= "order volume created";
            }
            catch (Exception ex)
            {

                result= ex.Message.ToString();
            }


            return result;
            
        }

        // DELETE: api/OrderVolumes/5
        [ResponseType(typeof(OrderProducedVolume))]
        public IHttpActionResult DeleteOrderProducedVolume(int id)
        {
            OrderProducedVolume orderProducedVolume = db.OrderProducedVolumes.Find(id);
            if (orderProducedVolume == null)
            {
                return NotFound();
            }

            db.OrderProducedVolumes.Remove(orderProducedVolume);
            db.SaveChanges();

            return Ok(orderProducedVolume);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderProducedVolumeExists(int id)
        {
            return db.OrderProducedVolumes.Count(e => e.ProducedVolumeId == id) > 0;
        }
    }
}