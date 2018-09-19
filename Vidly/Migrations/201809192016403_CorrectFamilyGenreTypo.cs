namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectFamilyGenreTypo : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MovieGenres SET Name = 'Family' WHERE Id = '3'");
        }
        
        public override void Down()
        {
        }
    }
}
