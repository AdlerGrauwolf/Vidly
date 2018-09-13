namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO MovieGenres (id, Name)
                              VALUES (1, 'Comedy'),
                                     (2, 'Action'),
                                     (3, 'Famaly'),
                                     (4, 'Romance'),
                                     (5, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
