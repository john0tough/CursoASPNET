namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMovieWithGenre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "GenreId");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}
