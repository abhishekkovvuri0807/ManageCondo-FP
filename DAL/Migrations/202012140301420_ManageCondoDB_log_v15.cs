namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_log_v15 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Parcels", "DateRecieved");
            DropColumn("dbo.Parcels", "DateReleased");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Parcels", "DateReleased", c => c.DateTime(nullable: false));
            AddColumn("dbo.Parcels", "DateRecieved", c => c.DateTime(nullable: false));
        }
    }
}
