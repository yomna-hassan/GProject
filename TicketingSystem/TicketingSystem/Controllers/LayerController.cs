﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    public class LayerController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        List<Layer> Layers = new List<Layer>();
        List<int> Layers_Id = new List<int>();
        List<Layer_SLA> Layer_Sla = new List<Layer_SLA>();
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [HttpGet]
        [Route("api/layer/{sla}")]
        public IHttpActionResult Get(int sla)
        {
            
            Layer_Sla = db.LayerSLAs.Where(n => n.SLAId == sla).ToList();
            //return Ok(Layer_Sla);
            foreach (var s in Layer_Sla)
            {
                Layers_Id.Add(s.LayerId);
            }
            foreach (var la in Layers_Id)
            {
                Layers.Add(db.Layers.Where(l => l.Layer_id == la).FirstOrDefault());
            }
            if (Layers == null)

                return Content(HttpStatusCode.NotFound, "errrrrrrrrror");
            else
                return Ok(Layers);

        }


    }
}
