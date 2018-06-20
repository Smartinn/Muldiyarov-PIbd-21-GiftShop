namespace GiftShopServiceWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migrat : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        GiftId = c.Int(nullable: false),
                        FacilitatorId = c.Int(),
                        Count = c.Int(nullable: false),
                        Summa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        DateCreate = c.DateTime(nullable: false),
                        DateImplement = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Facilitators", t => t.FacilitatorId)
                .ForeignKey("dbo.Gifts", t => t.GiftId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.GiftId)
                .Index(t => t.FacilitatorId);
            
            CreateTable(
                "dbo.Facilitators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacilitatorFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GiftName = c.String(nullable: false),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GiftElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GiftId = c.Int(nullable: false),
                        ElementId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Elements", t => t.ElementId, cascadeDelete: true)
                .ForeignKey("dbo.Gifts", t => t.GiftId, cascadeDelete: true)
                .Index(t => t.GiftId)
                .Index(t => t.ElementId);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElementName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StorageElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        ElementId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Elements", t => t.ElementId, cascadeDelete: true)
                .ForeignKey("dbo.Storages", t => t.StorageId, cascadeDelete: true)
                .Index(t => t.StorageId)
                .Index(t => t.ElementId);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GiftElements", "GiftId", "dbo.Gifts");
            DropForeignKey("dbo.StorageElements", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.GiftElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.Customs", "GiftId", "dbo.Gifts");
            DropForeignKey("dbo.Customs", "FacilitatorId", "dbo.Facilitators");
            DropForeignKey("dbo.Customs", "CustomerId", "dbo.Customers");
            DropIndex("dbo.StorageElements", new[] { "ElementId" });
            DropIndex("dbo.StorageElements", new[] { "StorageId" });
            DropIndex("dbo.GiftElements", new[] { "ElementId" });
            DropIndex("dbo.GiftElements", new[] { "GiftId" });
            DropIndex("dbo.Customs", new[] { "FacilitatorId" });
            DropIndex("dbo.Customs", new[] { "GiftId" });
            DropIndex("dbo.Customs", new[] { "CustomerId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageElements");
            DropTable("dbo.Elements");
            DropTable("dbo.GiftElements");
            DropTable("dbo.Gifts");
            DropTable("dbo.Facilitators");
            DropTable("dbo.Customs");
            DropTable("dbo.Customers");
        }
    }
}
