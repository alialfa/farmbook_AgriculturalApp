namespace FarmBook_v7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Crops",
                c => new
                    {
                        CropID = c.Int(nullable: false, identity: true),
                        CropName = c.String(nullable: false),
                        CropLocation = c.String(nullable: false),
                        CropContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CropID);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                        SupplierLocation = c.String(nullable: false),
                        SupplierAddress = c.String(nullable: false),
                        SupplierContent = c.String(),
                        Location_ID = c.Int(),
                    })
                .PrimaryKey(t => t.SupplierID)
                .ForeignKey("dbo.Location", t => t.Location_ID)
                .Index(t => t.Location_ID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryID = c.Int(nullable: false, identity: true),
                        Author = c.String(nullable: false),
                        Title = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StoryID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Suppliers", new[] { "Location_ID" });
            DropForeignKey("dbo.Suppliers", "Location_ID", "dbo.Location");
            DropTable("dbo.Stories");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Location");
            DropTable("dbo.Crops");
            DropTable("dbo.UserProfile");
        }
    }
}
