namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_log_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "IsActive");
        }
    }
}
