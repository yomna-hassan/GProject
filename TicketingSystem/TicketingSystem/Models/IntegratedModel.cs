using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketingSystem.Models
{
    public class IntegratedModel
    {

        public int  slaid{ get; set; }
        public string slaname { get; set; }
        public int l1time { get; set; }
        public int l2time { get; set; }
        public int l3time { get; set; }

        // public List<LayerModel> Layers { get; set; }
        public int Layer_id { get; set; }
    }

}