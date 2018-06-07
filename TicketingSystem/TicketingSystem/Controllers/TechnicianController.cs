using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    //Youmna
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TechnicianController : ApiController
    {
        List<ApplicationUser> Technicians = new List<ApplicationUser>();
        ApplicationDbContext db = new ApplicationDbContext();
        //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]

        [Route("api/technician/{Id}")]
        [HttpGet]
        public IHttpActionResult GetTechByLayer(int Id)
        {
            Technicians = db.Users.Where(u => u.layer_id == Id).ToList();
            if (Technicians == null)
                return NotFound();
            else
                return Ok(Technicians);
        }



    }
}
