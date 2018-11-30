namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resident", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resident", new[] { "User_Id" });
            AlterColumn("dbo.Resident", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Resident", "User_Id");
            AddForeignKey("dbo.Resident", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resident", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Resident", new[] { "User_Id" });
            AlterColumn("dbo.Resident", "User_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Resident", "User_Id");
            AddForeignKey("dbo.Resident", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
