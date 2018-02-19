namespace MovieShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values (1,0,0,0)");
            Sql("Insert Into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values (2,30,1,10)");
            Sql("Insert Into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values (3,90,3,15)");
            Sql("Insert Into MembershipTypes (Id,SignUpFee,DurationInMonths,DiscountRate) values (4,300,12,30)");
        }
        
        public override void Down()
        {
        }
    }
}
