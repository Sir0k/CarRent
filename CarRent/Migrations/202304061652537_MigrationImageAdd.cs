namespace CarRent.Migrations
{
    using CarRent.Entities;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationImageAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("AvailableCars", "ImageData", c => c.Binary(nullable: true));
        }
        
        public override void Down()
        {
        }
    }
}
