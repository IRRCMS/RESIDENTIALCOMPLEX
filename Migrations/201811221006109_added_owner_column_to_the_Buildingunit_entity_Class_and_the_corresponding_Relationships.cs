namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_owner_column_to_the_Buildingunit_entity_Class_and_the_corresponding_Relationships : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ResidentsCars", newName: "ResidentsCar");
            CreateTable(
                "dbo.Building_Owner",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        BuildingUnit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.BuildingUnit_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.BuildingUnit", t => t.BuildingUnit_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.BuildingUnit_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Building_Owner", "BuildingUnit_Id", "dbo.BuildingUnit");
            DropForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person");
            DropIndex("dbo.Building_Owner", new[] { "BuildingUnit_Id" });
            DropIndex("dbo.Building_Owner", new[] { "Person_Id" });
            DropTable("dbo.Building_Owner");
            RenameTable(name: "dbo.ResidentsCar", newName: "ResidentsCars");
        }
    }
}
