namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Layer_SLA", "Time", c => c.Int());
            DropColumn("dbo.SLA", "L1_Time");
            DropColumn("dbo.SLA", "L2_Time");
            DropColumn("dbo.SLA", "L3_Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SLA", "L3_Time", c => c.Int());
            AddColumn("dbo.SLA", "L2_Time", c => c.Int());
            AddColumn("dbo.SLA", "L1_Time", c => c.Int());
            DropColumn("dbo.Layer_SLA", "Time");
        }
    }
}
