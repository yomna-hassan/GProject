namespace TicketingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layer");
            DropIndex("dbo.AspNetUsers", new[] { "layer_id" });
            AlterColumn("dbo.AspNetUsers", "layer_id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "layer_id");
            AddForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layer", "Layer_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layer");
            DropIndex("dbo.AspNetUsers", new[] { "layer_id" });
            AlterColumn("dbo.AspNetUsers", "layer_id", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "layer_id");
            AddForeignKey("dbo.AspNetUsers", "layer_id", "dbo.Layer", "Layer_id", cascadeDelete: true);
        }
    }
}
