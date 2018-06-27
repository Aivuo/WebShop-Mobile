namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CellPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseYear = c.String(),
                        Price = c.Single(nullable: false),
                        Colors = c.String(),
                        ScreenSize = c.String(),
                        Retina = c.Boolean(nullable: false),
                        WarehouseStock = c.Int(nullable: false),
                        News = c.Boolean(nullable: false),
                        ProductCode = c.String(),
                        CameraPixels = c.String(),
                        Developer = c.String(),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        BillingAdress = c.String(),
                        BillingZip = c.String(),
                        BillingCity = c.String(),
                        DeliveryAdress = c.String(),
                        DeliveryZip = c.String(),
                        DeliveryCity = c.String(),
                        EmailAdress = c.String(),
                        PhoneNumber = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                        Date = c.String(),
                        CellPhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CellPhones", t => t.CellPhoneId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CellPhoneId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderRows", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderRows", "CellPhoneId", "dbo.CellPhones");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderRows", new[] { "CellPhoneId" });
            DropIndex("dbo.OrderRows", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.OrderRows");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CellPhones");
        }
    }
}
