namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class some_refinements_in_models : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person");
            //DropForeignKey("dbo.ResidentsCar", "PersonId", "dbo.Person");
            //DropPrimaryKey("dbo.Person");
            CreateTable(
                "dbo.Resident",
                c => new
                    {
                        ResidentId = c.Int(nullable: false, identity: true),
                        NumOfOccupants = c.Int(nullable: false),
                        BuildingUnitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResidentId);
            
            CreateTable(
                "dbo.Cost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Wage = c.Int(nullable: false),
                        Maintenance = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BuildingUnit", "UnitNo", c => c.String());
            AddColumn("dbo.BuildingUnit", "PersonId", c => c.Int(nullable: false));
            AddColumn("dbo.BuildingUnit", "Resident_ResidentId", c => c.Int());
            AlterColumn("dbo.Person", "Id", c => c.Int(nullable: false));
            //AddPrimaryKey("dbo.Person", "Id");
            CreateIndex("dbo.Person", "Id");
            CreateIndex("dbo.BuildingUnit", "Resident_ResidentId");
            AddForeignKey("dbo.Person", "Id", "dbo.Resident", "ResidentId");
            AddForeignKey("dbo.BuildingUnit", "Resident_ResidentId", "dbo.Resident", "ResidentId");
            //AddForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person", "Id", cascadeDelete: true);
            //AddForeignKey("dbo.ResidentsCar", "PersonId", "dbo.Person", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentsCar", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.BuildingUnit", "Resident_ResidentId", "dbo.Resident");
            DropForeignKey("dbo.Person", "Id", "dbo.Resident");
            DropIndex("dbo.BuildingUnit", new[] { "Resident_ResidentId" });
            DropIndex("dbo.Person", new[] { "Id" });
            DropPrimaryKey("dbo.Person");
            AlterColumn("dbo.Person", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.BuildingUnit", "Resident_ResidentId");
            DropColumn("dbo.BuildingUnit", "PersonId");
            DropColumn("dbo.BuildingUnit", "UnitNo");
            DropTable("dbo.Cost");
            DropTable("dbo.Resident");
            AddPrimaryKey("dbo.Person", "Id");
            AddForeignKey("dbo.ResidentsCar", "PersonId", "dbo.Person", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person", "Id", cascadeDelete: true);
        }
    }
}
