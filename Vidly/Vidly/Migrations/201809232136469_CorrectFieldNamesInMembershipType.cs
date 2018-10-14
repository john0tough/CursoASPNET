namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectFieldNamesInMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.MembershipTypes", "DiscountRates", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DurationInMoth");
            DropColumn("dbo.MembershipTypes", "DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.MembershipTypes", "DurationInMoth", c => c.Byte(nullable: false));
            DropColumn("dbo.MembershipTypes", "DiscountRates");
            DropColumn("dbo.MembershipTypes", "DurationInMonths");
        }
    }
}
