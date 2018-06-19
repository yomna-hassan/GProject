using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace TicketingSystem.hubs
{
    [HubName("notificationHub")]
    public class NotificationHub : Hub
    {
        public void SendMessage(string msg)
        {
            //log the incoming message here to confirm that its received

            //send back same message with DateTime
            Clients.All.messageReceived(msg);
        }
    }
}