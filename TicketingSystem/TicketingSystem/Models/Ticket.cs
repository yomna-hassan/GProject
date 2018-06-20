using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TicketingSystem.Models
{

    public enum Status : byte { Done,Open,OnHold,OverDue};
    [Table("Ticket")]
    public class Ticket
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Ticket_Id { get; set; }

        [Required]
        public string Ticket_Name { get; set; }

    
        ///[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Ticket_date { get; set; }

        public string Description { get; set; }

        [Required]
        public string ClientName{ get; set; }
        public Status status { get; set; }

        [Required]
        [ForeignKey("Sla")]
        public int SLA_Id { get; set; }

        [XmlIgnore]
        [JsonIgnore]
        public virtual SLA Sla { get; set; }

        public List<UserTicket> UserTickets { get; set; }





    }
}