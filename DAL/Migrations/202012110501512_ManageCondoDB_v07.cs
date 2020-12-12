namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v07 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resident", "UnitID", c => c.Int(nullable: false));
            CreateIndex("dbo.Resident", "UnitID");
            AddForeignKey("dbo.Resident", "UnitID", "dbo.Unit", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resident", "UnitID", "dbo.Unit");
            DropIndex("dbo.Resident", new[] { "UnitID" });
            DropColumn("dbo.Resident", "UnitID");
        }
    }
}
