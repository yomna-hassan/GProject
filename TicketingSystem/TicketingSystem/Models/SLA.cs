using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketingSystem;

namespace TicketingSystem.Models
{
    public class SLA
    {
        [Key]
        public int SLA_id{ get; set; }
        [Required]
        public string SLA_name { get; set; }
        [Required]
        public DateTime time1 { get; set; }
        [Required]
        public DateTime time2 { get; set; }
        [Required]
        public DateTime time3 { get; set; }
        [ForeignKey("Layer")]
        public int layer_id { get; set; }
        public List<Ticket> tickets { get; set; }
        public Layer Layer {get;set; }



    }
}