namespace GigHubApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GigsTableModifiednullabledatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gigs", "DateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gigs", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
