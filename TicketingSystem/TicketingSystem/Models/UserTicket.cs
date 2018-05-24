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
        public int user_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("tickets")]
        [Column(Order = 2)]
        public int ticket_id{ get; set; }
        public string status { get; set; }
        public  List<Ticket> tickets { get; set; }
        public List<ApplicationUser> Users { get; set; }

    }
}