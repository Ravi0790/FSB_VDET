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
    public class OrderDetailsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        // GET: api/OrderDetails
        public IQueryable<OrderDetail> GetOrderDetails()
        {
            return db.OrderDetails;
        }

        // GET: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult GetOrderDetail(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Include(p=>p.UserType).Include(p=>p.Shift).Include(p=>p.Line).Include(p => p.Product).SingleOrDefault(x=>x.OrderId==id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            return Ok(orderDetail);
        }

        
        [HttpGet]
        [Route("api/orderformula/{orderid}")]        
        public OrderFormula GetOrderFormulas(int orderid)
        {
            OrderFormula objformula = new OrderFormula();
            objformula = objformula.CreateFormula(orderid);

            
            return objformula;
        }


        public void UpdateOrderFinalStatus(int orderid)
        {
            OrderDetail objorder = db.OrderDetails.Include(x => x.OrderInfos).SingleOrDefault(x => x.OrderId == orderid);

            var statuscount = 0;
            foreach (var item in objorder.OrderInfos)
            {
                if (item.OrderStatus == 0)
                {
                    statuscount++;
                }
            }

            if (statuscount == 0)
            {
                objorder.FinalStatus = 1;
                db.SaveChanges();
            }

            

        }

        [HttpPost]
        [Route("api/orderformula/status")]
        public string UpdateOrderUserTypeStatus(OrderStatus orderstatus)
        {
            var orderinfo = db.OrderInfos.Include(x=>x.OrderDetail).SingleOrDefault(x => x.OrderId == orderstatus.OrderId && x.UserTypeId == orderstatus.UserTypeId);

            orderinfo.OrderStatus = 1;

            try
            {
                db.SaveChanges();
                UpdateOrderFinalStatus(orderstatus.OrderId);
                return "order status updated";
            }
            catch (Exception ex)
            {

                return ex.Message.ToString();
            }
                        
        }

        

        
        [HttpPost]
        [Route("api/orderdetails/update")]
        
        public string UpdateOrderDetails(OrderDetail orderDetail)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != orderDetail.OrderId)
            //{
            //    return BadRequest();
            //}

            //db.Entry(orderDetail).State = EntityState.Modified;

            var returnval = "failure";

            var order = db.OrderDetails.SingleOrDefault(x => x.OrderId == orderDetail.OrderId);

            if (orderDetail.UserTypeId != 2)
            {
                order.TeigteileruhrStartTime = orderDetail.TeigteileruhrStartTime;
                order.TeigteileruhrEndTime = orderDetail.TeigteileruhrEndTime;
                order.TeigteileruhrDurationMin = orderDetail.TeigteileruhrDurationMin;
                order.OrderEndTime = orderDetail.OrderEndTime;
                order.OrderDurationMin = orderDetail.OrderDurationMin;
                order.PlannedQuantity = orderDetail.PlannedQuantity;
            }
            else {
                order.ProducedQuantity = orderDetail.ProducedQuantity;
            }


            
            

            try
            {
                db.SaveChanges();

                
                var objformula=GetOrderFormulas(orderDetail.OrderId);

                order.BakeryTotalWaste = objformula.BakeryTotalWaste;
                order.PackageTotalWaste = objformula.PackageTotalWaste;
                order.TotalDowntime = objformula.TotalDowntime;
                order.TotalWasteKg = objformula.TotalWasteKg;
                order.TotalWastePieces = objformula.TotalWastePieces;
                order.TotalProduction = objformula.TotalProduction;
                order.Sollmengen = objformula.Sollmengen;
                order.StillStandMin = objformula.StillStandMin;
                order.StillStandPieces = objformula.StillStandPieces;
                order.LeerIndexMinute = objformula.LeerIndexMinute;
                order.LeerIndexPieces = objformula.LeerIndexPieces;
                order.PlannedKg = objformula.PlannedKg;
                order.ProducedKg = objformula.ProducedKg;

                db.SaveChanges();

                OrderStatus objstatus = new OrderStatus();
                objstatus.OrderId = orderDetail.OrderId;
                objstatus.UserTypeId = orderDetail.UserTypeId;

                UpdateOrderUserTypeStatus(objstatus);


                returnval = "success";

            }
            catch (DbUpdateConcurrencyException ex)
            {
                returnval = ex.Message.ToString();
            }

            return returnval;
        }

        // POST: api/OrderDetails
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult PostOrderDetail(OrderDetail orderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrderDetails.Add(orderDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orderDetail.OrderId }, orderDetail);
        }

        // DELETE: api/OrderDetails/5
        [ResponseType(typeof(OrderDetail))]
        public IHttpActionResult DeleteOrderDetail(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();

            return Ok(orderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderDetailExists(int id)
        {
            return db.OrderDetails.Count(e => e.OrderId == id) > 0;
        }
    }
}