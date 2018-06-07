using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    [Table("User-Ticket")]
    public class UserTicket
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("User")]
        [Column(Order = 1)]
        public string User_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("Ticket")]
        [Column(Order = 2)]
        public int Ticket_id{ get; set; }

        public DateTime? StartTicket { get; set; }

        //from enum in ticket
        public Status Status { get; set; }
        public  Ticket Ticket { get; set; }
        public ApplicationUser User { get; set; }

    }
}