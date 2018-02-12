namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Movies", "GendreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GendreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Movies", "GendreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Genres", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GendreId");
            AddForeignKey("dbo.Movies", "GendreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GendreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GendreId" });
            DropPrimaryKey("dbo.Genres");
            AlterColumn("dbo.Genres", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "GendreId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Genres", "Id");
            CreateIndex("dbo.Movies", "GendreId");
            AddForeignKey("dbo.Movies", "GendreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
