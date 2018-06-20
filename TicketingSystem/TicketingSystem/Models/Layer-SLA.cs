using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    [Table("Layer_SLA")]
    public class Layer_SLA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("Layer")]
        [Column(Order = 1)]
        public int LayerId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [ForeignKey("SLA")]
        [Column(Order = 2)]
        public int SLAId { get; set; }
        public int? Time { get; set; }

        public Layer Layer { get; set; }
        public SLA SLA { get; set; }

    }
}