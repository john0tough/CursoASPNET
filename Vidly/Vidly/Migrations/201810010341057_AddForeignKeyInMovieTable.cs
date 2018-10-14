namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyInMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("Update Movies set GenreId = 1 where GenreId = 0");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre");
        }
        
    }
}
