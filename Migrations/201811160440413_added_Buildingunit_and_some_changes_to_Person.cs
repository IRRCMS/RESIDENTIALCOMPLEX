namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_Buildingunit_and_some_changes_to_Person : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Single(nullable: false),
                        MonthlyCharge = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Person", "MartialStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "MartialStatus");
            DropTable("dbo.BuildingUnit");
        }
    }
}
