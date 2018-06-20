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
        public IHttpActionResult Post(IntegratedModel two)
        {
           
            if (two == null)
            {
                return BadRequest();
            }
            else
            {
                //dummy
               // two.slaid = 2000;
                SLA s = new SLA();

                //s.SLA_id = two.slaid;
                s.SLA_name = two.slaname;
                s.L1_Time = two.l1time;
                s.L2_Time = two.l2time;
                s.L3_Time = two.l3time;
                db.SLAs.Add(s);
                db.SaveChanges();

                List<Layer> layers = new List<Layer>();
                layers = db.Layers.ToList();

                for(int i=two.Layer_id;i<=layers.Count;i++)
                {
                    Layer_SLA LayerSla = new Layer_SLA();
                    LayerSla.SLAId = s.SLA_id;
                    LayerSla.LayerId = i;
                    db.LayerSLAs.Add(LayerSla);
                }

                db.SaveChanges();
                return Ok(two);
            }
            
        }
        [HttpPost]
        public IHttpActionResult Put(int id,IntegratedModel newsla)
        {
            SLA sla =db.SLAs.FirstOrDefault(s => s.SLA_id == id);
            List<Layer_SLA> layerssla = db.LayerSLAs.Where(s => s.SLAId == id).ToList();
            
            if (newsla == null)
            {
                return BadRequest();
            }
            else if(ModelState.IsValid==false)
            {
                return BadRequest();
            }
            else if(db.SLAs.FirstOrDefault(s=>s.SLA_id==id)==null)
            {
                return NotFound();
            }
            else
            {
                sla.SLA_name = newsla.slaname;
                sla.L1_Time = newsla.l1time;
                sla.L2_Time = newsla.l2time;
                sla.L3_Time = newsla.l3time;
                db.SaveChanges();

                foreach (var l in layerssla)
                {
                    // layers y3ny taba2at y3ny 7agat foo2 ba3daha kedaho kedahoooo 
                    l.LayerId = newsla.Layer_id;
                }
                db.SaveChanges();
                return Ok(newsla);
            }

        }
        [Route("api/slaa")]
        [HttpPost]
        public IHttpActionResult Delete(int Id)
        {
            SLA sla = db.SLAs.FirstOrDefault(s => s.SLA_id == Id);
            if (sla == null)
            {
                return NotFound();
            }
            else
            {
                db.SLAs.Remove(sla);
               // Slas.Remove(sla);
                db.SaveChanges();

                List<Layer_SLA> removable = new List<Layer_SLA>();
                removable = db.LayerSLAs.Where(n => n.SLAId == Id).ToList();

                foreach(var item in removable)
                {
                    layers_slas.Remove(item);
                }
                db.SaveChanges();

                

                return Ok(sla);
            }
        }
    }
}
