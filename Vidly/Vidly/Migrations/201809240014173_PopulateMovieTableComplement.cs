namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovieTableComplement : DbMigration
    {
        public override void Up()
        {
            Sql("insert into movies (name, genre, ReleaseDate, DateAdded, NumberInStock) values ('Die Hard', 'Action', '2017-11-01', getdate(), 10)");
            Sql("insert into movies (name, genre, ReleaseDate, DateAdded, NumberInStock) values ('The Terminator', 'Action', '2016-09-01', getdate(), 5)");
            Sql("insert into movies (name, genre, ReleaseDate, DateAdded, NumberInStock) values ('Toy Story', 'Family', '2000-08-01', getdate(), 2)");
            Sql("insert into movies (name, genre, ReleaseDate, DateAdded, NumberInStock) values ('Titanic', 'Romance', '1990-07-01', getdate(), 1)");
        }
        
        public override void Down()
        {
        }
    }
}
