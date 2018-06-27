namespace WebShop_Mobile.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Three : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderRows", "CellPhoneId_Id", c => c.Int());
            AddColumn("dbo.OrderRows", "OrdersId_Id", c => c.Int());
            AddColumn("dbo.Orders", "CustomerId_Id", c => c.Int());
            CreateIndex("dbo.OrderRows", "CellPhoneId_Id");
            CreateIndex("dbo.OrderRows", "OrdersId_Id");
            CreateIndex("dbo.Orders", "CustomerId_Id");
            AddForeignKey("dbo.OrderRows", "CellPhoneId_Id", "dbo.CellPhones", "Id");
            AddForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.OrderRows", "OrdersId_Id", "dbo.Orders", "Id");
            DropColumn("dbo.OrderRows", "OrderId");
            DropColumn("dbo.OrderRows", "CellPhoneId");
            DropColumn("dbo.Orders", "CustomersId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "CustomersId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "CellPhoneId", c => c.Int(nullable: false));
            AddColumn("dbo.OrderRows", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderRows", "OrdersId_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId_Id", "dbo.Customers");
            DropForeignKey("dbo.OrderRows", "CellPhoneId_Id", "dbo.CellPhones");
            DropIndex("dbo.Orders", new[] { "CustomerId_Id" });
            DropIndex("dbo.OrderRows", new[] { "OrdersId_Id" });
            DropIndex("dbo.OrderRows", new[] { "CellPhoneId_Id" });
            DropColumn("dbo.Orders", "CustomerId_Id");
            DropColumn("dbo.OrderRows", "OrdersId_Id");
            DropColumn("dbo.OrderRows", "CellPhoneId_Id");
        }
    }
}
