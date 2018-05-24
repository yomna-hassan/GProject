using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TicketingSystem.Models
{
    public class Presence
    {
        public int user_id { get; set; }
        public DateTime presence_date{ get; set; }
        public bool Presence_status { get; set; }

    }
}