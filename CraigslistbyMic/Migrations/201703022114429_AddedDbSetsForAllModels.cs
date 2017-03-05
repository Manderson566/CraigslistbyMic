namespace CraigslistbyMic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbSetsForAllModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageUploads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        File = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        CityId = c.Int(nullable: false),
                        SubCatagoryId = c.Int(nullable: false),
                        OwnerId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.SubCatagories", t => t.SubCatagoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.OwnerId)
                .Index(t => t.CityId)
                .Index(t => t.SubCatagoryId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.SubCatagories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CatagoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catagories", t => t.CatagoryId, cascadeDelete: true)
                .Index(t => t.CatagoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "OwnerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Posts", "SubCatagoryId", "dbo.SubCatagories");
            DropForeignKey("dbo.SubCatagories", "CatagoryId", "dbo.Catagories");
            DropForeignKey("dbo.Posts", "CityId", "dbo.Cities");
            DropIndex("dbo.SubCatagories", new[] { "CatagoryId" });
            DropIndex("dbo.Posts", new[] { "OwnerId" });
            DropIndex("dbo.Posts", new[] { "SubCatagoryId" });
            DropIndex("dbo.Posts", new[] { "CityId" });
            DropTable("dbo.SubCatagories");
            DropTable("dbo.Posts");
            DropTable("dbo.ImageUploads");
            DropTable("dbo.Cities");
            DropTable("dbo.Catagories");
        }
    }
}
