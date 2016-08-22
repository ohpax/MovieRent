namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Adventure')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (6, 'Musical')");
        }
        
        public override void Down()
        {
        }
    }
}
