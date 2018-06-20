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

        List<ApplicationUser> Layer1Technician = new List<ApplicationUser>();
        List<ApplicationUser> Layer2Technician = new List<ApplicationUser>();
        List<ApplicationUser> Layer3Technician = new List<ApplicationUser>();

       // List<List<ApplicationUser>> AllTechnician = new List<List<ApplicationUser>>();

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

        [HttpGet]
        [Route("api/technician/1")]
        public IHttpActionResult Get1Layer()
        {
            Layer1Technician = db.Users.Where(t => t.layer_id == 1).ToList();
            //Layer2Technician = db.Users.Where(t => t.layer_id == 2).ToList();
            //Layer3sTechnician = db.Users.Where(t => t.layer_id == 3).ToList();

            //AllTechnician.Add(Layer1Technician);
            //AllTechnician.Add(Layer2Technician);
            //AllTechnician.Add(Layer3sTechnician);

            if (Layer1Technician == null)
                return NotFound();
            else
            {
                return Ok(Layer1Technician);
            }

        }

        [HttpGet]
        [Route("api/technician/2")]
        public IHttpActionResult Get2Layer()
        {
            Layer2Technician= db.Users.Where(t => t.layer_id == 2).ToList();

            if (Layer2Technician == null)
                return NotFound();
            else
            {
                return Ok(Layer2Technician);
            }

        }

        [HttpGet]
        [Route("api/technician/3")]
        public IHttpActionResult Get3Layer()
        {
            Layer3Technician = db.Users.Where(t => t.layer_id == 3).ToList();

            if (Layer3Technician == null)
                return NotFound();
            else
            {
                return Ok(Layer3Technician);
            }

        }





    }
}
