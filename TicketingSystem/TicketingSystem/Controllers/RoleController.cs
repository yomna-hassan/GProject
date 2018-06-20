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
    public class RoleController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
<<<<<<< HEAD
        [Route("api/role")]
=======
        [Route("api/role/get")]
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978
        public IHttpActionResult Get()
        {

            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var roles = rolemanager.Roles.Select(x => new { x.Id, x.Name }).ToList();

            return Ok(roles);

        }

    }
}
