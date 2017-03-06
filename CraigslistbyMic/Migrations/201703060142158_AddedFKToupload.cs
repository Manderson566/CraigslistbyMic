namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFKToupload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ImageUploads", "PostId", c => c.Int(nullable: false));
            AddColumn("dbo.Posts", "Img_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "Img_Id");
            AddForeignKey("dbo.Posts", "Img_Id", "dbo.ImageUploads", "Id", cascadeDelete: true);
            DropColumn("dbo.ImageUploads", "Caption");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ImageUploads", "Caption", c => c.String());
            DropForeignKey("dbo.Posts", "Img_Id", "dbo.ImageUploads");
            DropIndex("dbo.Posts", new[] { "Img_Id" });
            DropColumn("dbo.Posts", "Img_Id");
            DropColumn("dbo.ImageUploads", "PostId");
        }
    }
}
