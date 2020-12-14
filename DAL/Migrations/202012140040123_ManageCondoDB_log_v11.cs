namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_log_v11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Courier = c.String(nullable: false, maxLength: 255),
                        isIncoming = c.Boolean(nullable: false),
                        NumberOfPeices = c.Int(nullable: false),
                        DateRecieved = c.DateTime(nullable: false),
                        DateReleased = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 1000),
                        IsActive = c.Boolean(nullable: false),
                        ResidentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resident", t => t.ResidentID, cascadeDelete: true)
                .Index(t => t.ResidentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "ResidentID", "dbo.Resident");
            DropIndex("dbo.Parcels", new[] { "ResidentID" });
            DropTable("dbo.Parcels");
        }
    }
}
