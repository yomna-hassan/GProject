using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using TicketingSystem.Models;

namespace TicketingSystem
{
    [HubName("hubTicket")]
    public class MyHub1 : Hub
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public void createTicket(Ticket myTicket, string userId)
        {

            db.Tickets.Add(myTicket);
            db.SaveChanges();

            UserTicket newuserticket = new UserTicket();
            newuserticket.User_id = userId;
            newuserticket.Ticket_id = myTicket.Ticket_Id;
            newuserticket.StartTicket = DateTime.Now;
            newuserticket.Status = Status.OnHold;
            db.UserTickets.Add(newuserticket);
            db.SaveChanges();

            List<string> connectionIds = db.ConnectedUsers.Where(c => c.UserId == userId).Select(x => x.ConnectionId).ToList();
            foreach (string connectionId in connectionIds)
            {
                Clients.Client(connectionId).newTicket(userId);
            }

        }
        public override Task OnConnected()
        {
            ConnectedUser connecteduser = new ConnectedUser();
            //connecteduser.UserId= Context.QueryString['id'];
            connecteduser.ConnectionId = Context.ConnectionId;
            db.ConnectedUsers.Add(connecteduser);
            db.SaveChanges();
            return base.OnConnected();
        }
      
    }
}