namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class set_person_martial_status_to_10_character : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Person", "MartialStatus", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Person", "MartialStatus", c => c.String());
        }
    }
}
