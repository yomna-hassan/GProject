using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
   // [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class TickController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<Ticket> Tickets = new List<Ticket>();

       [Route("api/Tick/{UserId}")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]Ticket newTicket, [FromUri]string UserId)//
        {
            if (newTicket == null)
            {
                return BadRequest();
            }
            else
            {

                newTicket.status = Status.OnHold;

                //newticket.Ticket_date = Convert.ToDateTime("2018-06-04 04:13:30.1");
                // newticket.Ticket_date = DateTime.Now;
                //Add to ticket table
                db.Tickets.Add(newTicket);

                UserTicket UserTicket = new UserTicket();
                UserTicket.Ticket_id = newTicket.Ticket_Id;
                UserTicket.User_id = UserId;
                UserTicket.Status = Status.OnHold;

                //Add to userticket table
                db.UserTickets.Add(UserTicket);
                db.SaveChanges();
                return Created("Ticket:", newTicket);


            }
        }
    }
}
