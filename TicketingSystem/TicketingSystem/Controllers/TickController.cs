using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TicketingSystem.Models;
using TicketingSystem.View_Models;

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
                newTicket.Ticket_date = DateTime.Now;

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
                
                //publish the update to signal r hub
                //Hubs.NotificationHub.BroadcastCommonDataStatic(newTicket);
                return Created("Ticket:", newTicket);


            }
        }

        public List<Ticket> OnHoldTickets = new List<Ticket>();
        [Route("api/Tick/OnHold")]
        [HttpGet]
        [ResponseType(typeof(TicketTechnician))]
        public IHttpActionResult GetOnHold()
        {
            OnHoldTickets = db.Tickets.Where(x => x.status == Status.OnHold).ToList();
            if (OnHoldTickets == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(map(OnHoldTickets));
            }

        }
       

        public List<Ticket> OpendedTickets = new List<Ticket>();
        [Route("api/Tick/Opened")]
        [HttpGet]
        public IHttpActionResult GetOpened()
        {
            OpendedTickets = db.Tickets.Where(x => x.status == Status.Open).ToList();
            if (OpendedTickets == null)
            {
                return NotFound();
            }
            else
                return Ok(map(OpendedTickets));

        }

        public List<Ticket> OverdueTickets = new List<Ticket>();
        [Route("api/Tick/Overdue")]
        [HttpGet]
        public IHttpActionResult GetOverdue()
        {
            OverdueTickets = db.Tickets.Where(x => x.status == Status.OverDue).ToList();
            if (OverdueTickets == null)
            {
                return NotFound();
            }
            else
                return Ok(map(OverdueTickets));

        }

        public List<Ticket> DoneTickets = new List<Ticket>();
        [Route("api/Tick/Done")]
        [HttpGet]
        public IHttpActionResult GetDone()
        {
            DoneTickets = db.Tickets.Where(x => x.status == Status.Done).ToList();
            if (DoneTickets == null)
            {
                return NotFound();
            }
            else
                return Ok(map(DoneTickets));

        }

        public List<Ticket> UserHoldTickets = new List<Ticket>();
        public List<UserTicket> UserTickets = new List<UserTicket>();
        public List<int> TicketsIds = new List<int>();
        [Route("api/Tick/{Id}")]
        [HttpGet]
        public IHttpActionResult GetById([FromUri]string Id)
        {
            UserTickets = db.UserTickets.Where(a => a.User_id == Id&&a.Status==Status.OnHold).ToList();
            if (UserTickets != null)
            {
                foreach (var u in UserTickets)
                {
                    TicketsIds.Add(u.Ticket_id);
                }
                foreach (var t in TicketsIds)
                {
                    UserHoldTickets.Add(db.Tickets.FirstOrDefault(a => a.Ticket_Id == t));
                }
                return Ok(UserHoldTickets);
            }
            return NotFound();
        }

        Ticket OldTicket = new Ticket();
        UserTicket OldUserTicket = new UserTicket();
     
        [Route("api/Tick/{Id}")]  
        [HttpPut]
        public IHttpActionResult Put([FromUri]int Id,[FromBody]Ticket NewTicket)
        {
            OldTicket = db.Tickets.FirstOrDefault(a => a.Ticket_Id == NewTicket.Ticket_Id);
            OldTicket.status = Status.Open;
            OldUserTicket = db.UserTickets.FirstOrDefault(a => a.Ticket_id == NewTicket.Ticket_Id);
            OldUserTicket.Status = Status.Open;
            db.SaveChanges();
            return Ok(NewTicket);
        }
        public List<TicketTechnician> map(List<Ticket> ticket)
        {
            var tic = new List<TicketTechnician>();
            foreach (var item in ticket)
            {
                tic.Add(new TicketTechnician(item));
            }

            return tic;
        }

    }
}
