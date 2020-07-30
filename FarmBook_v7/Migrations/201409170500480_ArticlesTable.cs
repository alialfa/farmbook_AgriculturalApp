namespace FarmBook_v7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArticlesTable : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Articles");
        }
    }
}
