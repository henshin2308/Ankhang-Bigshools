namespace Ankhang_Bigshools.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowingsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follwings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follwings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follwings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Follwings", new[] { "FolloweeId" });
            DropIndex("dbo.Follwings", new[] { "FollowerId" });
            DropTable("dbo.Follwings");
        }
    }
}
