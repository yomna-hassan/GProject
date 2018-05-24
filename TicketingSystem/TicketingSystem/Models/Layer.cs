using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Layer
    {
        [Key]
        public int layer_id { get; set; }
        [Required]
        public string layer_name { get; set; }
        public ApplicationUser User { get; set; }
        public SLA sla { get; set; }

    }
}