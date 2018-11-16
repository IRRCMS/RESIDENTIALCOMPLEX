namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_person_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Family = c.String(nullable: false, maxLength: 50),
                        NationalCode = c.String(nullable: false, maxLength: 10),
                        Gender = c.String(nullable: false, maxLength: 1),
                        PhoneNumber = c.String(),
                        CellPhone = c.String(nullable: false),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NationalCode, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Person", new[] { "NationalCode" });
            DropTable("dbo.Person");
        }
    }
}
