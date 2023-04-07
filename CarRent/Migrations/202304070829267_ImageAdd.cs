﻿namespace CarRent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AvailableCars", "ImageData", c => c.Binary());
        }
        
        public override void Down()
        {
        }
    }
}
