namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProcessOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Processed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Processed");
        }
    }
}
