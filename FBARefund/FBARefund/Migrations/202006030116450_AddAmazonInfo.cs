namespace FBARefund.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmazonInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "SellerId", c => c.String());
            AddColumn("dbo.AspNetUsers", "DeveloperToken", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DeveloperToken");
            DropColumn("dbo.AspNetUsers", "SellerId");
        }
    }
}
