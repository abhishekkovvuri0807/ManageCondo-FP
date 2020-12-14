namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_log_v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcels", "Status", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parcels", "Status");
        }
    }
}
