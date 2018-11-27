namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some_corrections_in_person_user_table_relationship : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Person", new[] { "NationalCode" });
            AlterColumn("dbo.Person", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Person", "Family", c => c.String(maxLength: 50));
            AlterColumn("dbo.Person", "NationalCode", c => c.String(maxLength: 10));
            AlterColumn("dbo.Person", "Gender", c => c.String(maxLength: 1));
            CreateIndex("dbo.Person", "NationalCode", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Person", new[] { "NationalCode" });
            AlterColumn("dbo.Person", "Gender", c => c.String(nullable: false, maxLength: 1));
            AlterColumn("dbo.Person", "NationalCode", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Person", "Family", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Person", "Name", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Person", "NationalCode", unique: true);
        }
    }
}
