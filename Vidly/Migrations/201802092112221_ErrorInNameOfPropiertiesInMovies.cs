namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ErrorInNameOfPropiertiesInMovies : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "GendreId", newName: "GenreId");
            RenameIndex(table: "dbo.Movies", name: "IX_GendreId", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenreId", newName: "IX_GendreId");
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "GendreId");
        }
    }
}
