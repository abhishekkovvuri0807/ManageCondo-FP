namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManageCondoDB_v6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Property", "Phone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Property", "Phone", c => c.String());
        }
    }
}
