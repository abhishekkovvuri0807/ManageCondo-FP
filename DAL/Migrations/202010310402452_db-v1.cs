namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbv1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 1000),
                        Email = c.String(maxLength: 255),
                        Description = c.String(maxLength: 1000),
                        Status = c.String(maxLength: 255),
                        Info = c.String(maxLength: 255),
                        Infoinfo = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Description = c.String(maxLength: 1000),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Role");
            DropTable("dbo.Property");
        }
    }
}
