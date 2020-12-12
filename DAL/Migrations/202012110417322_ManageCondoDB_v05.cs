namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v05 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Resident",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResidentType = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false, maxLength: 255),
                        MoveInDate = c.DateTime(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        EmergencyNotes = c.String(maxLength: 1000),
                        EmergencyContact = c.String(maxLength: 1000),
                        HavePets = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ResidentUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ResidentUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResidentID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resident", t => t.ResidentID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.ResidentID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentUser", "UserID", "dbo.User");
            DropForeignKey("dbo.ResidentUser", "ResidentID", "dbo.Resident");
            DropIndex("dbo.ResidentUser", new[] { "UserID" });
            DropIndex("dbo.ResidentUser", new[] { "ResidentID" });
            DropTable("dbo.ResidentUser");
            DropTable("dbo.Resident");
        }
    }
}
