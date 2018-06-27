namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CellPhones", "ReleaseYear", c => c.String());
            AddColumn("dbo.CellPhones", "WarehouseStock", c => c.Int(nullable: false));
            AddColumn("dbo.CellPhones", "CameraPixels", c => c.String());
            AddColumn("dbo.CellPhones", "Developer", c => c.String());
            AlterColumn("dbo.CellPhones", "Price", c => c.Single(nullable: false));
            AlterColumn("dbo.OrderRows", "Price", c => c.Single(nullable: false));
            DropColumn("dbo.CellPhones", "ReliaseYear");
            DropColumn("dbo.CellPhones", "LagerSaldo");
            DropColumn("dbo.CellPhones", "CameraPixlar");
            DropColumn("dbo.CellPhones", "Tillverkare");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CellPhones", "Tillverkare", c => c.String());
            AddColumn("dbo.CellPhones", "CameraPixlar", c => c.String());
            AddColumn("dbo.CellPhones", "LagerSaldo", c => c.Int(nullable: false));
            AddColumn("dbo.CellPhones", "ReliaseYear", c => c.String());
            AlterColumn("dbo.OrderRows", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.CellPhones", "Price", c => c.String());
            DropColumn("dbo.CellPhones", "Developer");
            DropColumn("dbo.CellPhones", "CameraPixels");
            DropColumn("dbo.CellPhones", "WarehouseStock");
            DropColumn("dbo.CellPhones", "ReleaseYear");
        }
    }
}
