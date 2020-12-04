namespace ManageCondo.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bdv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "Infoinfo", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "Infoinfo");
        }
    }
}
