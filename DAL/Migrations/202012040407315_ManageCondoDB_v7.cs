namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Unit",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Level = c.Int(nullable: false),
                        FobKey = c.String(maxLength: 255),
                        isRentedOut = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Status = c.String(maxLength: 255),
                        isActive = c.Boolean(nullable: false),
                        PropertyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Property", t => t.PropertyID, cascadeDelete: true)
                .Index(t => t.PropertyID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Unit", "PropertyID", "dbo.Property");
            DropIndex("dbo.Unit", new[] { "PropertyID" });
            DropTable("dbo.Unit");
        }
    }
}
