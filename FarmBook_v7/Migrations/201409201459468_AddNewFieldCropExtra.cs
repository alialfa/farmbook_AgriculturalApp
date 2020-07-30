namespace FarmBook_v7.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewFieldCropExtra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Crops", "CropExtra", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Crops", "CropExtra");
        }
    }
}
