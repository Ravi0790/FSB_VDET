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
    public class OrderInfoesController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/OrderInfoes
        public IQueryable<OrderInfo> GetOrderInfos()
        {
            return db.OrderInfos;
        }

        // GET: api/OrderInfoes/5
        [ResponseType(typeof(OrderInfo))]
        public IHttpActionResult GetOrderInfo(int id)
        {
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            return Ok(orderInfo);
        }


        [HttpGet]
        [Route("api/orderinfoes/order/{orderid}")]
        public OrderDetail GetOrderInfoByOrder(int orderid)
        {
            //IList<OrderInfo> orderInfo = db.OrderInfos
            //                               .Include(x=>x.OrderDetail)
            //                               .Where(x=>x.OrderId==orderid).ToList();

            OrderDetail objorder = db.OrderDetails.Include(x => x.OrderInfos).SingleOrDefault(x => x.OrderId == orderid);

            return objorder;


        }

        // PUT: api/OrderInfoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOrderInfo(int id, OrderInfo orderInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderInfo.OrderInfoId)
            {
                return BadRequest();
            }

            db.Entry(orderInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderInfoExists(id))
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

        // POST: api/OrderInfoes
        [ResponseType(typeof(OrderInfo))]
        public IHttpActionResult PostOrderInfo(OrderInfo orderInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderInfos.Add(orderInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderInfo.OrderInfoId }, orderInfo);
        }

        // DELETE: api/OrderInfoes/5
        [ResponseType(typeof(OrderInfo))]
        public IHttpActionResult DeleteOrderInfo(int id)
        {
            OrderInfo orderInfo = db.OrderInfos.Find(id);
            if (orderInfo == null)
            {
                return NotFound();
            }

            db.OrderInfos.Remove(orderInfo);
            db.SaveChanges();

            return Ok(orderInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderInfoExists(int id)
        {
            return db.OrderInfos.Count(e => e.OrderInfoId == id) > 0;
        }
    }
}