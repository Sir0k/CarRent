namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailableCars", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AvailableCars", "ImageData");
        }
    }
}
