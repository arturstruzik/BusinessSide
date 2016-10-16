namespace BusinessSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalcAccess2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CalcAccessDate", "DateIsSet", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CalcAccessDate", "DateIsSet");
        }
    }
}
