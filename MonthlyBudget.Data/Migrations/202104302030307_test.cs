namespace MonthlyBudget.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CategoryName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.UtilityCompany",
                c => new
                    {
                        UtilityCompanyId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Website = c.String(nullable: false),
                        UserLogin = c.String(nullable: false),
                        UserPassword = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        UtilityCompany_UtilityCompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.UtilityCompanyId)
                .ForeignKey("dbo.UtilityCompany", t => t.UtilityCompany_UtilityCompanyId)
                .Index(t => t.UtilityCompany_UtilityCompanyId);
            
            CreateTable(
                "dbo.Description",
                c => new
                    {
                        DescriptionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        DescriptionName = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Description_DescriptionId = c.Int(),
                    })
                .PrimaryKey(t => t.DescriptionId)
                .ForeignKey("dbo.Description", t => t.Description_DescriptionId)
                .Index(t => t.Description_DescriptionId);
            
            CreateTable(
                "dbo.Checking",
                c => new
                    {
                        EntryId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        MonthlyBill = c.Boolean(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        UtilityCompanyId = c.Int(nullable: false),
                        DescriptionId = c.Int(nullable: false),
                        PayingById = c.Int(nullable: false),
                        ChargeDate = c.DateTime(nullable: false),
                        DateCleared = c.DateTime(nullable: false),
                        Cleared = c.Boolean(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Checking_EntryId = c.Int(),
                    })
                .PrimaryKey(t => t.EntryId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Description", t => t.DescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.Checking", t => t.Checking_EntryId)
                .ForeignKey("dbo.PayingBy", t => t.PayingById, cascadeDelete: true)
                .ForeignKey("dbo.UtilityCompany", t => t.UtilityCompanyId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UtilityCompanyId)
                .Index(t => t.DescriptionId)
                .Index(t => t.PayingById)
                .Index(t => t.Checking_EntryId);
            
            CreateTable(
                "dbo.PayingBy",
                c => new
                    {
                        PayById = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        CashOrCard = c.String(nullable: false),
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
            DropForeignKey("dbo.Checking", "UtilityCompanyId", "dbo.UtilityCompany");
            DropForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy");
            DropForeignKey("dbo.Checking", "Checking_EntryId", "dbo.Checking");
            DropForeignKey("dbo.Checking", "DescriptionId", "dbo.Description");
            DropForeignKey("dbo.Checking", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Description", "Description_DescriptionId", "dbo.Description");
            DropForeignKey("dbo.UtilityCompany", "UtilityCompany_UtilityCompanyId", "dbo.UtilityCompany");
            DropForeignKey("dbo.Category", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Checking", new[] { "Checking_EntryId" });
            DropIndex("dbo.Checking", new[] { "PayingById" });
            DropIndex("dbo.Checking", new[] { "DescriptionId" });
            DropIndex("dbo.Checking", new[] { "UtilityCompanyId" });
            DropIndex("dbo.Checking", new[] { "CategoryId" });
            DropIndex("dbo.Description", new[] { "Description_DescriptionId" });
            DropIndex("dbo.UtilityCompany", new[] { "UtilityCompany_UtilityCompanyId" });
            DropIndex("dbo.Category", new[] { "Category_CategoryId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PayingBy");
            DropTable("dbo.Checking");
            DropTable("dbo.Description");
            DropTable("dbo.UtilityCompany");
            DropTable("dbo.Category");
        }
    }
}
