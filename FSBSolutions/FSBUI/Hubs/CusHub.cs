using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FSBUI.Hubs
{
    public class CusHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }


        public static void ShowVolume(string orderid)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<CusHub>();
            context.Clients.All.displayVolumes(orderid);
        }
    }
}