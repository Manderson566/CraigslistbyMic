namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedWordingInPostModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Posts", name: "Img_Id", newName: "ImageId");
            RenameIndex(table: "dbo.Posts", name: "IX_Img_Id", newName: "IX_ImageId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Posts", name: "IX_ImageId", newName: "IX_Img_Id");
            RenameColumn(table: "dbo.Posts", name: "ImageId", newName: "Img_Id");
        }
    }
}
