namespace BusinessSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CalcAccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CalcAccessDate",
                c => new
                    {
                        CalcAccessDateID = c.Int(nullable: false, identity: true),
                        DateTo = c.DateTime(nullable: false),
                        EmailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CalcAccessDateID)
                .ForeignKey("dbo.Email", t => t.EmailID, cascadeDelete: true)
                .Index(t => t.EmailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CalcAccessDate", "EmailID", "dbo.Email");
            DropIndex("dbo.CalcAccessDate", new[] { "EmailID" });
            DropTable("dbo.CalcAccessDate");
        }
    }
}
