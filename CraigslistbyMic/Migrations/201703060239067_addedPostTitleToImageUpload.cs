namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostTitleToImageUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageUploads", "PostTitle", c => c.String());
            DropColumn("dbo.ImageUploads", "PostId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageUploads", "PostId", c => c.Int(nullable: false));
            DropColumn("dbo.ImageUploads", "PostTitle");
        }
    }
}
