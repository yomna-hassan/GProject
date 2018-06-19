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
       public List<Layer_SLA> layers_slas = new List<Layer_SLA>();
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

        [HttpPost]
        public IHttpActionResult Post(SLA sla ,Layer_SLA[] layersSla)
        {
           
            if (sla == null)
            {
                return BadRequest();
            }
            else
            {
                db.SLAs.Add(sla);
                
                
                foreach(var l in layersSla)
                {
                    Layer_SLA LayerSla = new Layer_SLA();
                    LayerSla.SLAId = sla.SLA_id;
                    LayerSla.LayerId = l.LayerId;
                    layers_slas.Add(LayerSla);

                }
              


                db.SaveChanges();
                return Ok(sla);
            }
            
        }
        public IHttpActionResult Put(SLA newsla)
        {
           // SLA sla = Slas.Find(s => s.SLA_id == id);
            if (newsla == null)
            {
                return BadRequest();
            }
            else if(ModelState.IsValid==false)
            {
                return BadRequest();
            }
            else if(db.SLAs.FirstOrDefault(s=>s.SLA_id==newsla.SLA_id)==null)
            {
                return NotFound();
            }
            else
            {
                db.Entry(newsla).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }

        }

        public IHttpActionResult delete(int id)
        {
            SLA sla = Slas.Find(s => s.SLA_id == id);
            if (sla == null)
            {
                return NotFound();
            }
            else
            {
                Slas.Remove(sla);
                List<Layer_SLA> removable = new List<Layer_SLA>();
                removable = db.LayerSLAs.Where(n => n.SLAId == id).ToList();

                foreach(var item in removable)
                {
                    layers_slas.Remove(item);
                }

                

                return Ok(sla);
            }
        }
    }
}
