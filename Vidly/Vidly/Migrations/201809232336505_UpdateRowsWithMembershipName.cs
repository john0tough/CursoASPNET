namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRowsWithMembershipName : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set MembershipName='Pay as You Go' where Id = 1 ");
            Sql("update MembershipTypes set MembershipName='Monthly' where Id = 2 ");
            Sql("update MembershipTypes set MembershipName='Quarterly' where Id = 3 ");
            Sql("update MembershipTypes set MembershipName='Annual' where Id = 4 ");
        }
        
        public override void Down()
        {
        }
    }
}
