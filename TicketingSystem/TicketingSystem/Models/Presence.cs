using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class Presence
    {
       
        public int user_id { get; set; }
        public bool status { get; set; }

        public DateTime user_date { get; set; }

        public ApplicationUser user { get; set; }


    }
}