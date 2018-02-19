namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteMoviesGenreId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenresId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
        }
    }
}
