using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
   
    public class SlaController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<SLA> Slas = new List<SLA>();
        //[EnableCors(origins:"http://localhost:4200",headers:"*",methods:"*")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            Slas = db.SLAs.ToList();
            if (Slas == null)
                return NotFound();
            else
                return Ok(Slas);
        }
    }
}
