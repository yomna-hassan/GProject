using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.View_Models
{
    public class TicketTechnician
    {
        public int Ticket_Id { get; set; }
        public string Ticket_Name { get; set; }
        public DateTime? Ticket_date { get; set; }
        public string Description { get; set; }
        public string ClientName { get; set; }
        public Status status { get; set; }
        public List<string> UserNames { get; set; }
        public int SLA_Id { get; set; }
        public string SLA_name { get; set; }
        public string User_id { get; set; }
        public string UserName { get; set; }

        public TicketTechnician(Ticket ticket) {
            Ticket_Id = ticket.Ticket_Id;
            Ticket_Name = ticket.Ticket_Name;
            Ticket_date = ticket.Ticket_date;
            Description = ticket.Description;
            ClientName = ticket.ClientName;
            status = ticket.status;
            SLA_Id = ticket.SLA_Id;
            SLA_name = ticket.Sla.SLA_name;
            //UserNames = new List<string>();
            //foreach (var item in ticket.UserTicket)
            //{
            //    UserNames.Add(item.User.UserName);
            //}
            var result = ticket.UserTicket.FirstOrDefault();
            if (result != null)
            {
                User_id = result.User.Id;
                UserName = result.User.UserName;
            }

            
        }


    }
}