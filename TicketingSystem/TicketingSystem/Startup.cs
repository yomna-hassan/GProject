using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using TicketingSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(TicketingSystem.Startup))]

namespace TicketingSystem
{
    public partial class Startup
    {
        ApplicationDbContext db = new ApplicationDbContext();
        //create roles and assign super admin role to super admin user  
        private void CreateRoleAndUser()
        {
           
            var rolemanager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!rolemanager.RoleExists("SuperAdmin"))
            {
                var role = new IdentityRole();
                role.Name = "SuperAdmin";
                //role.Id = "1";
                rolemanager.Create(role);

                var user = new ApplicationUser();
                user.UserName = "ahmed";
                user.Email = "ahmed@gmail.com";

                string userpassword = "Ahmed_23";
                var checkuser= usermanager.Create(user, userpassword);

                if(checkuser.Succeeded)
                {
                    var result = usermanager.AddToRole(user.Id, "SuperAdmin");
                }
            }

            if (!rolemanager.RoleExists("Dispature"))
            {
                var role = new IdentityRole();
                role.Name = "Dispature";
                rolemanager.Create(role);   
            }

            if (!rolemanager.RoleExists("Technician"))
            {
                var role = new IdentityRole();
                role.Name = "Technician";
                rolemanager.Create(role);

                var tech = new ApplicationUser();
                tech.UserName = "Mohamed Kareem";
                tech.Email = "Mohamed@gmail.com";
                tech.layer_id = 1;

                string userpassword2 = "Mohamed_11";
                var checkuser2 = usermanager.Create(tech, userpassword2);

                if (checkuser2.Succeeded)
                {
                    var result = usermanager.AddToRole(tech.Id, "Technician");
                }

                var tech2 = new ApplicationUser();
                tech2.UserName = "Amir Ahmed";
                tech2.Email = "Amir@gmail.com";
                tech2.layer_id = 2;

                string userpassword3 = "Amir_10";
                var checkuser3 = usermanager.Create(tech2, userpassword3);

                if (checkuser3.Succeeded)
                {
                    var result = usermanager.AddToRole(tech2.Id, "Technician");
                }

                var tech3 = new ApplicationUser();
                tech2.UserName = "Waleed Seif";
                tech2.Email = "Waleed@gmail.com";
                tech2.layer_id = 3;

                string userpassword4 = "Waleed_33";
                var checkuser4 = usermanager.Create(tech3, userpassword4);

                if (checkuser4.Succeeded)
                {
                    var result = usermanager.AddToRole(tech3.Id, "Technician");
                }
            }
           
           


        }

  
        public void Configuration(IAppBuilder app)
        {

            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
            CreateRoleAndUser();
            app.MapSignalR();
            

        }
    }
}
