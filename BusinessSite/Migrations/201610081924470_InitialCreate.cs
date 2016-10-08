namespace BusinessSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Email",
                c => new
                    {
                        EmailID = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.EmailID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Email");
        }
    }
}
