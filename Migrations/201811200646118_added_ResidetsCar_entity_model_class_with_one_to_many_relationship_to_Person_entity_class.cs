namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_ResidetsCar_entity_model_class_with_one_to_many_relationship_to_Person_entity_class : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResidentsCars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePlateNumber = c.String(maxLength: 10),
                        Person_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Person_Id)
                .Index(t => t.Person_Id);
            
            AlterColumn("dbo.Person", "CellPhone", c => c.String(nullable: false, maxLength: 11));
            AlterColumn("dbo.Person", "EmailAddress", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentsCars", "Person_Id", "dbo.Person");
            DropIndex("dbo.ResidentsCars", new[] { "Person_Id" });
            AlterColumn("dbo.Person", "EmailAddress", c => c.String());
            AlterColumn("dbo.Person", "CellPhone", c => c.String(nullable: false));
            DropTable("dbo.ResidentsCars");
        }
    }
}
