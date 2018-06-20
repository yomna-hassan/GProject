using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TicketingSystem.Models;
using Microsoft.AspNet.SignalR.Hubs;

namespace TicketingSystem.Hubs
{
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {
        //required to let the Hub to be called from other server-side classes/controllers using static method
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        //send the data to all clients (called from client js)
        public void BroadcastCommonData(Ticket ticket)
        {
            Clients.All.BroadcastCommonData(ticket);
        }

        //calld from server c#

        public static void BroadcastCommonDataStatic(Ticket ticket)
        {
            hubContext.Clients.All.BroadcastCommonData(ticket);
        }

        //send the data to all clents (may be called from server c#)
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}