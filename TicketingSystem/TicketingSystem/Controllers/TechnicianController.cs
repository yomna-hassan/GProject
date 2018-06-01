using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    public class TechnicianController : ApiController
    {
        List<ApplicationUser> Technicians = new List<ApplicationUser>();
        ApplicationDbContext db = new ApplicationDbContext();
        public IHttpActionResult GetTechByLayer(int LayerId)
        {
            Technicians = db.Users.Where(u => u.layer_id == LayerId).ToList();
            if (Technicians == null)
                return NotFound();
            else
                return Ok(Technicians);
        }
    }
}
