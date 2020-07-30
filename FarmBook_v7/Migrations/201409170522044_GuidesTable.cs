namespace FarmBook_v7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GuidesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Guides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GuideName = c.String(nullable: false),
                        GuideContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Articles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ArticleName = c.String(nullable: false),
                        ArticleContent = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            DropTable("dbo.Guides");
        }
    }
}
