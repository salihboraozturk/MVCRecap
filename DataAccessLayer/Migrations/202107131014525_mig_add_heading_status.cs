﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_heading_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headings", "HeadingStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headings", "HeadingStatus");
        }
    }
}
