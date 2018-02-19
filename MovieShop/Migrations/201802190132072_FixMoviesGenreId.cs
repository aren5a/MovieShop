namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMoviesGenreId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "GenresId");
        }
    }
}
