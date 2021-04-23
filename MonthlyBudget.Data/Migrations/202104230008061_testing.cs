namespace MonthlyBudget.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.UtilityCompany",
                c => new
                    {
                        UtilityCompanyId = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        UserLogin = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        PayingById = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.UtilityCompanyId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.PayingBy", t => t.PayingById, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.PayingById);
            
            CreateTable(
                "dbo.PayingBy",
                c => new
                    {
                        PayById = c.Int(nullable: false, identity: true),
                        CashOrCard = c.String(),
                        CashAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CardType = c.String(),
                        CardNumber = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NameOnCard = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        SecurityCode = c.Int(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.PayById);
            
            CreateTable(
                "dbo.Description",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        DescriptionName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.DescriptionId);
            
            CreateTable(
                "dbo.Checking",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CategoryId = c.Int(),
                        MonthlyBill = c.Boolean(nullable: false),
                        DescriptionId = c.Int(nullable: false),
                        PayingById = c.Int(nullable: false),
                        ChargeDate = c.DateTime(nullable: false),
                        DateCleared = c.DateTime(nullable: false),
                        Cleared = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Description", t => t.DescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.PayingBy", t => t.PayingById, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.DescriptionId)
                .Index(t => t.PayingById);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy");
            DropForeignKey("dbo.Checking", "DescriptionId", "dbo.Description");
            DropForeignKey("dbo.Checking", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.UtilityCompany", "PayingById", "dbo.PayingBy");
            DropForeignKey("dbo.UtilityCompany", "CategoryId", "dbo.Category");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Checking", new[] { "PayingById" });
            DropIndex("dbo.Checking", new[] { "DescriptionId" });
            DropIndex("dbo.Checking", new[] { "CategoryId" });
            DropIndex("dbo.UtilityCompany", new[] { "PayingById" });
            DropIndex("dbo.UtilityCompany", new[] { "CategoryId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Checking");
            DropTable("dbo.Description");
            DropTable("dbo.PayingBy");
            DropTable("dbo.UtilityCompany");
            DropTable("dbo.Category");
        }
    }
}
