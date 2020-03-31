using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FSBAPI.Models.FusionCharts;
using FSBAPI.Models.FusionCharts.Charts;
using FSBModel;
using System.Data.Entity;
using System.Collections;

namespace FSBAPI.Controllers
{
    public class FusionChartsController : ApiController
    {
        private FSBDBContext db = new FSBDBContext();

        [HttpGet]
        [Route("api/fusioncharts/dailyproduction")]
        public GanttChart GetDailyProduction(string cdate,int lineid) //date format : dd/MM/yyyy
        {
            

            DateTime startdate = Convert.ToDateTime(cdate);
            DateTime enddate = Convert.ToDateTime(cdate).AddDays(1);



            IList<OrderDetail> orderdetail = db.OrderDetails
                                            //.Include(o => o.Line)
                                            .Include(o => o.Product)
                                            //.Include(o => o.Shift)
                                            .Where(o => o.CreatedDate.Year == startdate.Year && o.CreatedDate.Month == startdate.Month && o.CreatedDate.Day == startdate.Day && o.LineId == lineid && o.FinalStatus == 1)
                                            .OrderBy(x => x.OrderId).ToList();


            var count = orderdetail.Count;

            GanttChart objganttchart = new GanttChart();

            objganttchart.type = "gantt";
            objganttchart.width = "100%";
            objganttchart.height = "150";
            objganttchart.dataFormat = "json";

            dataSource objdatasource = new dataSource();


            //chart

            chart objchart = new chart();
            objchart.theme = "fusion";
            objchart.dateformat = "dd/mm/yyyy hh:mn";
            objchart.showTaskLabels = 1;


            //task

            gtask[] arrtask = new gtask[count];


            for (int i = 0; i < count; i++)
            {
                var objtask = new gtask();

                objtask.label = orderdetail[i].Product.ProductDesc;
                objtask.processid = "A";
                objtask.start = orderdetail[i].OrderStartTime.ToString("dd/MM/yyyy HH:mm");

                DateTime endtime = orderdetail[i].OrderEndTime ?? DateTime.Now;
                objtask.end = endtime.ToString("dd/MM/yyyy HH:mm");

                objtask.color = "#" + orderdetail[i].Product.ProductColor;
                objtask.alpha = "85";

                arrtask[i] = objtask;
            }

            gtasks objtasks = new gtasks();

            objtasks.task = arrtask;


            //processes

            processes objprocesses = new processes();

            process[] arrprocess = new process[1];

            process objprocess = new process();
            objprocess.label = orderdetail[0].OrderStartTime.ToString("dd/MM/yyyy");
            objprocess.id = "A";

            arrprocess[0] = objprocess;

            objprocesses.isbold = "1";
            objprocesses.process = arrprocess;


            //categories

            categories[] arrcategories = new categories[1];

            categories objcategories = new categories();

            objcategories.bgalpha = "0";

            //category1

            category[] arrcategory1 = new category[1];

            category objcategory1 = new category();

            objcategory1.start = startdate.ToString("dd/MM/yyyy 06:00");
            objcategory1.end = enddate.ToString("dd/MM/yyyy 06:00");
            objcategory1.label = "";

            arrcategory1[0] = objcategory1;
            objcategories.category1 = arrcategory1;

            //category

            category[] arrcategory = new category[24];

            int arrcategorycount = arrcategory.Length;

            for (int i = 0;  i < arrcategorycount; i++)
            {
                int k = i + 1;

                int stime = 6 + i;
                int etime = 6 + k;


                int starttime = stime >= 24 ? stime - 24 : stime;
                int endtime = etime >= 24 ? etime - 24 : etime;

                string startimeformat = starttime.ToString().Length == 1 ? "0" + starttime.ToString() + ":00" : starttime.ToString() + ":00";
                string endtimeformat = endtime.ToString().Length == 1 ? "0" + endtime.ToString() + ":00" : endtime.ToString() + ":00";

                category objcategory = new category();
                objcategory.start = stime >= 24 ? enddate.ToString("dd/MM/yyyy " + startimeformat + "") : startdate.ToString("dd/MM/yyyy " + startimeformat + "");
                objcategory.end = stime >= 23 ? enddate.ToString("dd/MM/yyyy " + endtimeformat + "") : startdate.ToString("dd/MM/yyyy " + endtimeformat + "");
                objcategory.label = startimeformat;

                arrcategory[i] = objcategory;
            }


            objcategories.category = arrcategory;


            arrcategories[0] = objcategories;

            objdatasource.chart = objchart;
            objdatasource.tasks = objtasks;
            objdatasource.processes = objprocesses;
            objdatasource.categories = arrcategories;

            objganttchart.dataSource = objdatasource;


            return objganttchart;

        }
    }
}
