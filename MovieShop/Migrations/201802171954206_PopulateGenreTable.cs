namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into Genres (Genre) VALUES ('Comedy')");
            Sql("Insert Into Genres (Genre) VALUES ('Romance')");
            Sql("Insert Into Genres (Genre) VALUES ('Action')");
            Sql("Insert Into Genres (Genre) VALUES ('Drama')");
        }
        
        public override void Down()
        {
        }
    }
}
