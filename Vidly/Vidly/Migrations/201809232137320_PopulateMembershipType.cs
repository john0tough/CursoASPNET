namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipType : DbMigration
    {
        public override void Up()         
        {
            Sql("Insert Into MembershipTypes (Id ,SignUpFee , DurationInMonths ,DiscountRates ) Values (1,0,0,0)");
            Sql("Insert Into MembershipTypes (Id ,SignUpFee , DurationInMonths ,DiscountRates ) Values (2,30,1,10)");
            Sql("Insert Into MembershipTypes (Id ,SignUpFee , DurationInMonths ,DiscountRates ) Values (3,90,2,15)");
            Sql("Insert Into MembershipTypes (Id ,SignUpFee , DurationInMonths ,DiscountRates ) Values (4,300,20,20)");
        }
        
        public override void Down()
        {
        }
    }
}
