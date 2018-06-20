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
<<<<<<< HEAD
        public IHttpActionResult Post(IntegratedModel two)
        {
           
            if (two == null)
=======
        public IHttpActionResult Post(SLA sla ,Layer_SLA[] layersSla)
        {
           
            if (sla == null)
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978
            {
                return BadRequest();
            }
            else
            {
<<<<<<< HEAD
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
            
=======
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
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978
            if (newsla == null)
            {
                return BadRequest();
            }
            else if(ModelState.IsValid==false)
            {
                return BadRequest();
            }
<<<<<<< HEAD
            else if(db.SLAs.FirstOrDefault(s=>s.SLA_id==id)==null)
=======
            else if(db.SLAs.FirstOrDefault(s=>s.SLA_id==newsla.SLA_id)==null)
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978
            {
                return NotFound();
            }
            else
            {
<<<<<<< HEAD
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
=======
                db.Entry(newsla).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Ok();
            }

        }

        public IHttpActionResult delete(int id)
        {
            SLA sla = Slas.Find(s => s.SLA_id == id);
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978
            if (sla == null)
            {
                return NotFound();
            }
            else
            {
<<<<<<< HEAD
                db.SLAs.Remove(sla);
               // Slas.Remove(sla);
                db.SaveChanges();

                List<Layer_SLA> removable = new List<Layer_SLA>();
                removable = db.LayerSLAs.Where(n => n.SLAId == Id).ToList();
=======
                Slas.Remove(sla);
                List<Layer_SLA> removable = new List<Layer_SLA>();
                removable = db.LayerSLAs.Where(n => n.SLAId == id).ToList();
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978

                foreach(var item in removable)
                {
                    layers_slas.Remove(item);
                }
<<<<<<< HEAD
                db.SaveChanges();
=======
>>>>>>> 578d4c7ee5b60ecc797f719bcee5e2c97e7e4978

                

                return Ok(sla);
            }
        }
    }
}
