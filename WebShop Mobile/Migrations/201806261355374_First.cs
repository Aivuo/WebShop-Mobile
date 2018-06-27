namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CellPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReliaseYear = c.String(),
                        Price = c.String(),
                        Colors = c.String(),
                        Retina = c.Boolean(nullable: false),
                        LagerSaldo = c.Int(nullable: false),
                        News = c.Boolean(nullable: false),
                        ProductCode = c.String(),
                        CameraPixlar = c.String(),
                        Tillverkare = c.String(),
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
                "dbo.OrderRows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Date = c.String(),
                        CellPhone = c.String(),
                        CellPhoneId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        CustomersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.OrderRows");
            DropTable("dbo.Customers");
            DropTable("dbo.CellPhones");
        }
    }
}
