namespace IRRCMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AfterDrop : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BuildingUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.Single(nullable: false),
                        UnitNo = c.String(),
                        MonthlyCharge = c.Int(nullable: false),
                        Payment = c.Int(nullable: false),
                        PaymentStatus = c.Boolean(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        ResidentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Family = c.String(maxLength: 50),
                        NationalCode = c.String(maxLength: 10),
                        Gender = c.String(maxLength: 1),
                        PhoneNumber = c.String(),
                        MartialStatus = c.String(maxLength: 10),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.NationalCode, unique: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Resident",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumOfOccupants = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        BuildingUnit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BuildingUnit", t => t.BuildingUnit_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.BuildingUnit_Id);
            
            CreateTable(
                "dbo.ResidentsCar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LicensePlateNumber = c.String(maxLength: 10),
                        Resident_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resident", t => t.Resident_Id, cascadeDelete: true)
                .Index(t => t.Resident_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Person", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resident", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ResidentsCar", "Resident_Id", "dbo.Resident");
            DropForeignKey("dbo.Resident", "BuildingUnit_Id", "dbo.BuildingUnit");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Building_Owner", "BuildingUnit_Id", "dbo.BuildingUnit");
            DropForeignKey("dbo.Building_Owner", "Person_Id", "dbo.Person");
            DropIndex("dbo.Building_Owner", new[] { "BuildingUnit_Id" });
            DropIndex("dbo.Building_Owner", new[] { "Person_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ResidentsCar", new[] { "Resident_Id" });
            DropIndex("dbo.Resident", new[] { "BuildingUnit_Id" });
            DropIndex("dbo.Resident", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Person", new[] { "User_Id" });
            DropIndex("dbo.Person", new[] { "NationalCode" });
            DropTable("dbo.Building_Owner");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Cost");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ResidentsCar");
            DropTable("dbo.Resident");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Person");
            DropTable("dbo.BuildingUnit");
        }
    }
}
