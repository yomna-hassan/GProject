using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Ticket
    {
        /// <summary>
        /// 
        /// </summary>
      [Key]
        public int ticket_id { get; set; }
        [Required]
        public string ticket_name { get; set; }
        [Required]
        public DateTime ticket_date { get; set; }

        public string description { get; set; }
        [Required]
        public string clientName{ get; set; }
        [Required]
        public int SLA_id { get; set; }

        public SLA sla { get; set; }

        public string status {get; set; }






    }
}