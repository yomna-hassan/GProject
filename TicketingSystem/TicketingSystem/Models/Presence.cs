using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    [Table("Presence")]
    public class Presence
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [Column(Order =1)]
        [ForeignKey("User")]
        public int user_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 2)]
        public DateTime Presence_date { get; set; } = DateTime.Now;
        public bool Presence_status { get; set; }
        public ApplicationUser User { get; set; }


    }
}