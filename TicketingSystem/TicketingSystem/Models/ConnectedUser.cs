using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{     //ana zhhh2t
    [Table("ConnectedUser")]
    public class ConnectedUser
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        //yoooooooh b2aaaaaaaa
        [Key]
        public string ConnectionId { get; set; }

    }
}