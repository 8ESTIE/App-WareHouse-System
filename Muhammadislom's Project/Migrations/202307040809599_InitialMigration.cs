namespace Muhammadislom_s_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Imports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupplierId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remain = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductSuppliers",
                c => new
                    {
                        Product_Id = c.Int(nullable: false),
                        Supplier_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_Id, t.Supplier_Id })
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Supplier_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Imports", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.ProductSuppliers", "Supplier_Id", "dbo.Suppliers");
            DropForeignKey("dbo.ProductSuppliers", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.ProductSuppliers", new[] { "Supplier_Id" });
            DropIndex("dbo.ProductSuppliers", new[] { "Product_Id" });
            DropIndex("dbo.Imports", new[] { "SupplierId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.ProductSuppliers");
            DropTable("dbo.Products");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Imports");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
