using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class UserTicket
    {
        [Key]
        public int user_id { get; set; }
        [Key]
        public int ticket_id{ get; set; }
        public string status { get; set; }
        public Ticket ticket { get; set; }
        public ApplicationUser User{ get; set; }

    }
}