namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_ResidetsCar_entity_model_class_with_one_to_many_relationship_to_Person_entity_class1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ResidentsCars", "Person_Id", "dbo.Person");
            DropIndex("dbo.ResidentsCars", new[] { "Person_Id" });
            RenameColumn(table: "dbo.ResidentsCars", name: "Person_Id", newName: "PersonId");
            AlterColumn("dbo.ResidentsCars", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.ResidentsCars", "PersonId");
            AddForeignKey("dbo.ResidentsCars", "PersonId", "dbo.Person", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResidentsCars", "PersonId", "dbo.Person");
            DropIndex("dbo.ResidentsCars", new[] { "PersonId" });
            AlterColumn("dbo.ResidentsCars", "PersonId", c => c.Int());
            RenameColumn(table: "dbo.ResidentsCars", name: "PersonId", newName: "Person_Id");
            CreateIndex("dbo.ResidentsCars", "Person_Id");
            AddForeignKey("dbo.ResidentsCars", "Person_Id", "dbo.Person", "Id");
        }
    }
}
