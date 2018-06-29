namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CellPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        ReleaseYear = c.String(unicode: false),
                        Price = c.Single(nullable: false),
                        Retina = c.Boolean(nullable: false),
                        WarehouseStock = c.Int(nullable: false),
                        News = c.Boolean(nullable: false),
                        ProductCode = c.String(unicode: false),
                        CameraPixels = c.String(unicode: false),
                        Developer = c.String(unicode: false),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(unicode: false),
                        Lastname = c.String(unicode: false),
                        BillingAdress = c.String(unicode: false),
                        BillingZip = c.String(unicode: false),
                        BillingCity = c.String(unicode: false),
                        DeliveryAdress = c.String(unicode: false),
                        DeliveryZip = c.String(unicode: false),
                        DeliveryCity = c.String(unicode: false),
                        EmailAdress = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        Password = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(unicode: false),
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
                        Price = c.Single(nullable: false),
                        Date = c.String(unicode: false),
                        OrderId = c.Int(nullable: false),
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
