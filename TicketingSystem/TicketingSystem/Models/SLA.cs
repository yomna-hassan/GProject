using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TicketingSystem;

namespace TicketingSystem.Models
{
    [Table("SLA")]
    public class SLA
    {
        [Key]
        public int SLA_id{ get; set; }
        [Required]
        public string SLA_name { get; set; }
        
        public int? L1_Time { get; set; }
      
        public int? L2_Time { get; set; }
        
        public int? L3_Time { get; set; }

        public List<Ticket> tickets { get; set; }
        public List<Layer_SLA> LayerSLAs {get;set; }




    }
}