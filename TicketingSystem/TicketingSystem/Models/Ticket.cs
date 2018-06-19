using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace TicketingSystem.Models
{

    public enum Status : byte { Done,Open,OnHold,OverDue};
    [DataContract]
    [Table("Ticket")]
    public class Ticket
    {
        [DataMember]
        [Key]
        public int Ticket_Id { get; set; }

        [DataMember]
        [Required]
        public string Ticket_Name { get; set; }


        [DataMember]
        ///[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? Ticket_date { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public string ClientName{ get; set; }
        [DataMember]
        public Status status { get; set; }

        [DataMember]
        [Required]
        [ForeignKey("Sla")]
        public int SLA_Id { get; set; }


        [XmlIgnore]
        [JsonIgnore]
        public virtual SLA Sla { get; set; }

        public virtual List<UserTicket> UserTicket { get; set; }





    }
}