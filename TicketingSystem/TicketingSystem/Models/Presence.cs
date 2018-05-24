using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Presence
    {
        [ForeignKey("User")]
        public int UserId { get; set; }
        public bool Status { get; set; }

        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }


    }
}