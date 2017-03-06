namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPriceToDatabase : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Price", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Price");
        }
    }
}
