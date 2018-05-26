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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("Users")]
        [Column(Order = 1)]
        public int User_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("Tickets")]
        [Column(Order = 2)]
        public int Ticket_id{ get; set; }
        public string Status { get; set; }
        public  List<Ticket> Tickets { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}