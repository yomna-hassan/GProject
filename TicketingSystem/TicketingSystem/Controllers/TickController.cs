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
        
        //[EnableCors("*","*","*")]
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
        [Route("api/Tick/Hold/{Id}")]
        [HttpGet]
        public IHttpActionResult GetHoldById([FromUri]string Id)
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

        public List<Ticket> UserOpenedTickets = new List<Ticket>();
        [Route("api/Tick/Opened/{Id}")]
        [HttpGet]
        public IHttpActionResult GetOpenedById([FromUri]string Id)
        {
            UserTickets = db.UserTickets.Where(a => a.User_id == Id && a.Status == Status.Open).ToList();
            if (UserTickets != null)
            {
                foreach (var u in UserTickets)
                {
                    TicketsIds.Add(u.Ticket_id);
                }
                foreach (var t in TicketsIds)
                {
                    UserOpenedTickets.Add(db.Tickets.FirstOrDefault(a => a.Ticket_Id == t));
                }
                return Ok(UserOpenedTickets);
            }
            return NotFound();
        }

        Ticket OldTicket = new Ticket();
        UserTicket OldUserTicket = new UserTicket();
     
        [Route("api/Tick/Update/Hold/{Id}")]  
        [HttpPost]
        public IHttpActionResult PutHold([FromUri]string Id,[FromBody]Ticket NewTicket)
        {
            OldTicket = db.Tickets.FirstOrDefault(a => a.Ticket_Id == NewTicket.Ticket_Id);
            OldTicket.status = Status.Open;
            OldUserTicket = db.UserTickets.FirstOrDefault(a => a.Ticket_id == NewTicket.Ticket_Id&&a.User_id==Id);
            OldUserTicket.Status = Status.Open;
            db.SaveChanges();
            Layer_SLA layerSla=db.LayerSLAs.OrderBy(a => a.LayerId).FirstOrDefault(s=>s.SLAId==NewTicket.SLA_Id);
            int? layerTime= layerSla.Time;
            return Ok(layerTime);
        }

        [Route("api/Tick/Update/Open/{Id}")]
        [HttpPost]
        public IHttpActionResult PutOpen([FromUri]string Id, [FromBody]Ticket NewTicket)
        {
            OldTicket = db.Tickets.FirstOrDefault(a => a.Ticket_Id == NewTicket.Ticket_Id);
            OldTicket.status = Status.Done;
            OldUserTicket = db.UserTickets.FirstOrDefault(a => a.Ticket_id == NewTicket.Ticket_Id&&a.User_id==Id);
            OldUserTicket.Status = Status.Done;
            db.SaveChanges();
            return Ok();
        }

        [Route("api/Tick/Update/Undone/{Id}")]
        [HttpPost]
        public IHttpActionResult PutUndone([FromUri]string Id, [FromBody]Ticket NewTicket)
        {
            UserTicket UndoneUserTicket=db.UserTickets.FirstOrDefault(a => a.User_id == Id && a.Ticket_id == NewTicket.Ticket_Id);
            UndoneUserTicket.Status = Status.OverDue;
            ApplicationUser UndoneUser = db.Users.FirstOrDefault(a => a.Id == Id);
            int? layerId = UndoneUser.layer_id;
            //Edit ticket status and assign it to another one
            NewTicket.status = Status.OnHold;
            if (layerId < db.Layers.Count())
            {
                layerId += 1;
                List<ApplicationUser> UsersOfNextLayer = new List<ApplicationUser>();
                //get random user from next layer
                UsersOfNextLayer =db.Users.Where(a=>a.layer_id==layerId).ToList();
                Random rnd = new Random();
                int r = rnd.Next(UsersOfNextLayer.Count());
                ApplicationUser RandomUser = UsersOfNextLayer[r];

                UserTicket UserTicket = new UserTicket();
                UserTicket.Ticket_id = NewTicket.Ticket_Id;
                UserTicket.User_id = RandomUser.Id;
                UserTicket.Status = Status.OnHold;

                //Add to userticket table
                db.UserTickets.Add(UserTicket);
                db.SaveChanges();
                return Ok(RandomUser);
            }

            //there's no more layers
            return StatusCode(HttpStatusCode.NoContent);
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
