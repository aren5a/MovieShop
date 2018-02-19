namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoviesGenreId : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Genre_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Genre_id", c => c.Int());
            CreateIndex("dbo.Movies", "Genre_Id");
        }
    }
}
