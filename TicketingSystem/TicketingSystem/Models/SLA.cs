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
        public DateTime L1_Time { get; set; }
        [Required]
        public DateTime L2_Time { get; set; }
        [Required]
        public DateTime L3_Time { get; set; }

        [ForeignKey("Layers")]
        public int layer_id { get; set; }
        public List<Ticket> tickets { get; set; }


        public List<Layer> Layers {get;set; }
        public List<ApplicationUser> Users { get; set; }
        //try this comment to test git extin



    }
}