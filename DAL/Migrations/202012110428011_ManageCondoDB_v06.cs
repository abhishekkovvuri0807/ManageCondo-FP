namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v06 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResidentUser", "ResidentID", "dbo.Resident");
            DropForeignKey("dbo.ResidentUser", "UserID", "dbo.User");
            DropIndex("dbo.ResidentUser", new[] { "ResidentID" });
            DropIndex("dbo.ResidentUser", new[] { "UserID" });
            AddColumn("dbo.Resident", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Resident", "UserID");
            AddForeignKey("dbo.Resident", "UserID", "dbo.User", "ID", cascadeDelete: true);
            DropColumn("dbo.Resident", "ResidentUserID");
            DropTable("dbo.ResidentUser");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResidentUser",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResidentID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Resident", "ResidentUserID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Resident", "UserID", "dbo.User");
            DropIndex("dbo.Resident", new[] { "UserID" });
            DropColumn("dbo.Resident", "UserID");
            CreateIndex("dbo.ResidentUser", "UserID");
            CreateIndex("dbo.ResidentUser", "ResidentID");
            AddForeignKey("dbo.ResidentUser", "UserID", "dbo.User", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ResidentUser", "ResidentID", "dbo.Resident", "ID", cascadeDelete: true);
        }
    }
}
