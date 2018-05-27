using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{

    public enum Status : byte { Done,Open,OnHold,OverDue};
    [Table("Ticket")]
    public class Ticket
    {

        [Key]
        public int Ticket_Id { get; set; }

        [Required]
        public string Ticket_Name { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Ticket_date { get; set; } = DateTime.Now;

        public string Description { get; set; }

        [Required]
        public string ClientName{ get; set; }
        public Status status { get; set; }

        [Required]
        [ForeignKey("Sla")]
        public int SLA_Id { get; set; }
        public SLA Sla { get; set; }

        public List<UserTicket> UserTickets { get; set; }





    }
}