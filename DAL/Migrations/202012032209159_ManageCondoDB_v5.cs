namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "phone", c => c.String());
            DropColumn("dbo.Property", "Info");
            DropColumn("dbo.Property", "Infoinfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Property", "Infoinfo", c => c.String(maxLength: 255));
            AddColumn("dbo.Property", "Info", c => c.String(maxLength: 255));
            DropColumn("dbo.Property", "phone");
        }
    }
}
