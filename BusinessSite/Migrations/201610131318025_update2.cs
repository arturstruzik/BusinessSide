namespace BusinessSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CalcAccessDate", "EmailID", "dbo.Email");
            DropIndex("dbo.CalcAccessDate", new[] { "EmailID" });
            AddColumn("dbo.Email", "CalcAccessDateID", c => c.Int());
            CreateIndex("dbo.Email", "CalcAccessDateID");
            AddForeignKey("dbo.Email", "CalcAccessDateID", "dbo.CalcAccessDate", "CalcAccessDateID");
            DropColumn("dbo.CalcAccessDate", "EmailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CalcAccessDate", "EmailID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Email", "CalcAccessDateID", "dbo.CalcAccessDate");
            DropIndex("dbo.Email", new[] { "CalcAccessDateID" });
            DropColumn("dbo.Email", "CalcAccessDateID");
            CreateIndex("dbo.CalcAccessDate", "EmailID");
            AddForeignKey("dbo.CalcAccessDate", "EmailID", "dbo.Email", "EmailID", cascadeDelete: true);
        }
    }
}
