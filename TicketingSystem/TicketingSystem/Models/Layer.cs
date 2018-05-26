using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    [Table("Layer")]
    public class Layer
    {
        [Key]
        public int Layer_id { get; set; }
        [Required]
        public string Layer_name { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public List<Layer_SLA> LayerSLAs { get; set; }

    }
}