namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class person_to_applicationuser_relationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Person", "User_Id");
            AddForeignKey("dbo.Person", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Person", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Person", new[] { "User_Id" });
            DropColumn("dbo.Person", "User_Id");
        }
    }
}
