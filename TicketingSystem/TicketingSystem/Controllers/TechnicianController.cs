using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    //Youmna
    public class TechnicianController : ApiController
    {
        List<ApplicationUser> Technicians = new List<ApplicationUser>();
        ApplicationDbContext db = new ApplicationDbContext();
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        [Route("api/technician/{LayerId}")]
        [HttpGet]
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
