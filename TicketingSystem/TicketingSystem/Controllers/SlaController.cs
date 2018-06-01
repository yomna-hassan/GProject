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
        public List<SLA> SLAs { get; set; }

        public IHttpActionResult Get()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            SLAs = db.SLAs.ToList();
            if (SLAs == null)
                return NotFound();
            return Ok(SLAs);
        }

    }
}
