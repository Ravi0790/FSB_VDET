using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FSBModel;
using System.Data.Entity;
using System.Globalization;

namespace FSBUI.Models
{
    public class OrderInformation
    {
        private FSBDBContext db = new FSBDBContext();

        public IList<OrderDetail> OrderDetails { get; set; }

        public IList<OrderInfo> OrderInfos { get; set; }

        public IList<OrderDetail> CheckOrderPending(int lineid)
        {
            //DateTime startdate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            //DateTime enddate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy",CultureInfo.InvariantCulture));

            //DateTime startdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            //DateTime enddate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            DateTime startdate = DateTime.Now.AddDays(-1);
            DateTime enddate = DateTime.Now.AddDays(1);

            IList <OrderDetail> orderdetail = db.OrderDetails
                                            //.Include(x => x.OrderInfos)
                                            //.Where(x=>x.CreatedDate >= startdate && x.CreatedDate <= enddate && x.LineId==lineid && x.FinalStatus==0).ToList();
                                            .Where(o => o.CreatedDate.Year == startdate.Year && o.CreatedDate.Month == startdate.Month && o.CreatedDate.Day == startdate.Day && o.LineId == lineid && o.FinalStatus==0).ToList();
                                            //.Where(o => o.CreatedDate.Year == startdate.Year && o.CreatedDate.Month == startdate.Month && o.LineId == lineid).ToList();
            //.Where(o=>o.LineId==lineid).ToList();

            return orderdetail;

        }


        public OrderInformation GetPendingOrderDetails(int lineid)
        {
            //DateTime startdate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
            //DateTime enddate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

            //DateTime startdate = Convert.ToDateTime(DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));
            //DateTime enddate = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture));

            DateTime startdate = DateTime.Now.AddDays(-1);
            DateTime enddate = DateTime.Now.AddDays(1);

            OrderInformation objinformation = new OrderInformation()
            {
                OrderDetails = db.OrderDetails
                                            .Include(o => o.Line)
                                            .Include(o => o.Product)
                                            .Include(o => o.Shift)
                                            .Where(o => o.CreatedDate.Year == startdate.Year && o.CreatedDate.Month == startdate.Month && o.CreatedDate.Day == startdate.Day && o.LineId == lineid && o.FinalStatus==0)
                                            .OrderByDescending(x => x.OrderId).ToList(),

                OrderInfos = db.OrderInfos
                                            .Include(o => o.UserType)
                                            .Include(o => o.User)
                                            .Where(o => o.LoggedinTime.Year == startdate.Year && o.LoggedinTime.Month == startdate.Month && o.LoggedinTime.Day == startdate.Day && o.OrderDetail.LineId == lineid)
                                            .OrderByDescending(x => x.OrderId).ToList()
            };

            return objinformation;

        }
    }
}