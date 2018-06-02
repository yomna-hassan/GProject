namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConnectedUser",
                c => new
                    {
                        ConnectionId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ConnectionId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        image = c.String(),
                        layer_id = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Layer", t => t.layer_id)
                .Index(t => t.layer_id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Layer",
                c => new
                    {
                        Layer_id = c.Int(nullable: false, identity: true),
                        Layer_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Layer_id);
            
            CreateTable(
                "dbo.Layer_SLA",
                c => new
                    {
                        LayerId = c.Int(nullable: false),
                        SLAId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.LayerId, t.SLAId })
                .ForeignKey("dbo.Layer", t => t.LayerId, cascadeDelete: true)
                .ForeignKey("dbo.SLA", t => t.SLAId, cascadeDelete: true)
                .Index(t => t.LayerId)
                .Index(t => t.SLAId);
            
            CreateTable(
                "dbo.SLA",
                c => new
                    {
                        SLA_id = c.Int(nullable: false, identity: true),
                        SLA_name = c.String(nullable: false),
                        L1_Time = c.Int(),
                        L2_Time = c.Int(),
                        L3_Time = c.Int(),
                    })
                .PrimaryKey(t => t.SLA_id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Ticket_Id = c.Int(nullable: false),
                        Ticket_Name = c.String(nullable: false),
                        Ticket_date = c.DateTime(nullable: false),
                        Description = c.String(),
                        ClientName = c.String(nullable: false),
                        status = c.Byte(nullable: false),
                        SLA_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Ticket_Id)
                .ForeignKey("dbo.SLA", t => t.SLA_Id, cascadeDelete: true)
                .Index(t => t.SLA_Id);
            
            CreateTable(
                "dbo.User-Ticket",
                c => new
                    {
                        User_id = c.String(nullable: false, maxLength: 128),
                        Ticket_id = c.Int(nullable: false),
                        StartTicket = c.DateTime(nullable: false),
                        Status = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_id, t.Ticket_id })
                .ForeignKey("dbo.Ticket", t => t.Ticket_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_id, cascadeDelete: true)
                .Index(t => t.User_id)
                .Index(t => t.Ticket_id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Presence",
                c => new
                    {
                        user_id = c.String(nullable: false, maxLength: 128),
                        Presence_date = c.DateTime(nullable: false),
                        Presence_status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.Presence_date })
                .ForeignKey("dbo.AspNetUsers", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ConnectedUser", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Presence", "user_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layer");
            DropForeignKey("dbo.Layer_SLA", "SLAId", "dbo.SLA");
            DropForeignKey("dbo.User-Ticket", "User_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.User-Ticket", "Ticket_id", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "SLA_Id", "dbo.SLA");
            DropForeignKey("dbo.Layer_SLA", "LayerId", "dbo.Layer");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Presence", new[] { "user_id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.User-Ticket", new[] { "Ticket_id" });
            DropIndex("dbo.User-Ticket", new[] { "User_id" });
            DropIndex("dbo.Ticket", new[] { "SLA_Id" });
            DropIndex("dbo.Layer_SLA", new[] { "SLAId" });
            DropIndex("dbo.Layer_SLA", new[] { "LayerId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "layer_id" });
            DropIndex("dbo.ConnectedUser", new[] { "UserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Presence");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.User-Ticket");
            DropTable("dbo.Ticket");
            DropTable("dbo.SLA");
            DropTable("dbo.Layer_SLA");
            DropTable("dbo.Layer");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ConnectedUser");
        }
    }
}
