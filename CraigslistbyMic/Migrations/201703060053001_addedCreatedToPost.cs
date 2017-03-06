namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedCreatedToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Created");
        }
    }
}
