namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "image", c => c.String());
        }
    }
}
