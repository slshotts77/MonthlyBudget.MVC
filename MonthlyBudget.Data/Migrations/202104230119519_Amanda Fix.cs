namespace MonthlyBudget.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmandaFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Checking", "DescriptionId", "dbo.Description");
            DropForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy");
            DropIndex("dbo.Checking", new[] { "DescriptionId" });
            DropIndex("dbo.Checking", new[] { "PayingById" });
            AlterColumn("dbo.Checking", "DescriptionId", c => c.Int());
            AlterColumn("dbo.Checking", "PayingById", c => c.Int());
            CreateIndex("dbo.Checking", "DescriptionId");
            CreateIndex("dbo.Checking", "PayingById");
            AddForeignKey("dbo.Checking", "DescriptionId", "dbo.Description", "DescriptionId");
            AddForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy", "PayById");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy");
            DropForeignKey("dbo.Checking", "DescriptionId", "dbo.Description");
            DropIndex("dbo.Checking", new[] { "PayingById" });
            DropIndex("dbo.Checking", new[] { "DescriptionId" });
            AlterColumn("dbo.Checking", "PayingById", c => c.Int(nullable: false));
            AlterColumn("dbo.Checking", "DescriptionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Checking", "PayingById");
            CreateIndex("dbo.Checking", "DescriptionId");
            AddForeignKey("dbo.Checking", "PayingById", "dbo.PayingBy", "PayById", cascadeDelete: true);
            AddForeignKey("dbo.Checking", "DescriptionId", "dbo.Description", "DescriptionId", cascadeDelete: true);
        }
    }
}
