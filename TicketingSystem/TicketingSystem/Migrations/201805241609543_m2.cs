namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Layers",
                c => new
                    {
                        layer_id = c.Int(nullable: false, identity: true),
                        layer_name = c.String(nullable: false),
                        sla_SLA_id = c.Int(),
                    })
                .PrimaryKey(t => t.layer_id)
                .ForeignKey("dbo.SLAs", t => t.sla_SLA_id)
                .Index(t => t.sla_SLA_id);
            
            CreateTable(
                "dbo.SLAs",
                c => new
                    {
                        SLA_id = c.Int(nullable: false, identity: true),
                        SLA_name = c.String(nullable: false),
                        L1_Time = c.DateTime(nullable: false),
                        L2_Time = c.DateTime(nullable: false),
                        L3_Time = c.DateTime(nullable: false),
                        layer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SLA_id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ticket_id = c.Int(nullable: false, identity: true),
                        ticket_name = c.String(nullable: false),
                        ticket_date = c.DateTime(nullable: false),
                        description = c.String(),
                        clientName = c.String(nullable: false),
                        SLA_id = c.Int(nullable: false),
                        status = c.String(),
                        UserTicket_user_id = c.Int(),
                        UserTicket_ticket_id = c.Int(),
                    })
                .PrimaryKey(t => t.ticket_id)
                .ForeignKey("dbo.SLAs", t => t.SLA_id, cascadeDelete: true)
                .ForeignKey("dbo.UserTickets", t => new { t.UserTicket_user_id, t.UserTicket_ticket_id })
                .Index(t => t.SLA_id)
                .Index(t => new { t.UserTicket_user_id, t.UserTicket_ticket_id });
            
            CreateTable(
                "dbo.Presences",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        presence_date = c.DateTime(nullable: false),
                        Presence_status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.presence_date });
            
            CreateTable(
                "dbo.UserTickets",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        ticket_id = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => new { t.user_id, t.ticket_id });
            
            AddColumn("dbo.AspNetUsers", "image", c => c.String());
            AddColumn("dbo.AspNetUsers", "layer_id", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "SLA_id", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "presence_user_id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "presence_presence_date", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "userticket_user_id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "userticket_ticket_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "layer_id");
            CreateIndex("dbo.AspNetUsers", "SLA_id");
            CreateIndex("dbo.AspNetUsers", new[] { "presence_user_id", "presence_presence_date" });
            CreateIndex("dbo.AspNetUsers", new[] { "userticket_user_id", "userticket_ticket_id" });
            AddForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layers", "layer_id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", new[] { "presence_user_id", "presence_presence_date" }, "dbo.Presences", new[] { "user_id", "presence_date" });
            AddForeignKey("dbo.AspNetUsers", "SLA_id", "dbo.SLAs", "SLA_id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUsers", new[] { "userticket_user_id", "userticket_ticket_id" }, "dbo.UserTickets", new[] { "user_id", "ticket_id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", new[] { "userticket_user_id", "userticket_ticket_id" }, "dbo.UserTickets");
            DropForeignKey("dbo.Tickets", new[] { "UserTicket_user_id", "UserTicket_ticket_id" }, "dbo.UserTickets");
            DropForeignKey("dbo.AspNetUsers", "SLA_id", "dbo.SLAs");
            DropForeignKey("dbo.AspNetUsers", new[] { "presence_user_id", "presence_presence_date" }, "dbo.Presences");
            DropForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layers");
            DropForeignKey("dbo.Tickets", "SLA_id", "dbo.SLAs");
            DropForeignKey("dbo.Layers", "sla_SLA_id", "dbo.SLAs");
            DropIndex("dbo.AspNetUsers", new[] { "userticket_user_id", "userticket_ticket_id" });
            DropIndex("dbo.AspNetUsers", new[] { "presence_user_id", "presence_presence_date" });
            DropIndex("dbo.AspNetUsers", new[] { "SLA_id" });
            DropIndex("dbo.AspNetUsers", new[] { "layer_id" });
            DropIndex("dbo.Tickets", new[] { "UserTicket_user_id", "UserTicket_ticket_id" });
            DropIndex("dbo.Tickets", new[] { "SLA_id" });
            DropIndex("dbo.Layers", new[] { "sla_SLA_id" });
            DropColumn("dbo.AspNetUsers", "userticket_ticket_id");
            DropColumn("dbo.AspNetUsers", "userticket_user_id");
            DropColumn("dbo.AspNetUsers", "presence_presence_date");
            DropColumn("dbo.AspNetUsers", "presence_user_id");
            DropColumn("dbo.AspNetUsers", "SLA_id");
            DropColumn("dbo.AspNetUsers", "layer_id");
            DropColumn("dbo.AspNetUsers", "image");
            DropTable("dbo.UserTickets");
            DropTable("dbo.Presences");
            DropTable("dbo.Tickets");
            DropTable("dbo.SLAs");
            DropTable("dbo.Layers");
        }
    }
}
