namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTable : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name, genre, ReleaseDate, DateAdded, NumberInStock) values ('HangOver', 'Comedy', '2016-01-01', getdate(), 10)");
        }
        
        public override void Down()
        {
        }
    }
}
