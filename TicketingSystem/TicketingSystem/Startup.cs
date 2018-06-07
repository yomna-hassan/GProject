﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using TicketingSystem.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.Owin.Cors;

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

             
            }
           
           


        }

  
        public void Configuration(IAppBuilder app)
        {

<<<<<<< HEAD
            //app.UseCors(CorsOptions.AllowAll);
=======
            app.UseCors(CorsOptions.AllowAll);
<<<<<<< HEAD

=======
>>>>>>> ccfe3c1a69bd02e3961fc437d87c69c92994ddee
>>>>>>> 49e9afba5e092a86fc8eb69ca512f0e2392fe694
>>>>>>> 235506d9d29dfd451b2d0c4cbdaec3153bfeac73
            ConfigureAuth(app);
            CreateRoleAndUser();
            app.MapSignalR();
            

        }
    }
}
