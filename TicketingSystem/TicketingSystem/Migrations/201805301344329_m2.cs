namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "num");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "num", c => c.Int());
        }
    }
}
