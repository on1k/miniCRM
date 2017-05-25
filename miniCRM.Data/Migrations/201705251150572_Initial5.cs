namespace miniCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Acts", "CompanyID", "dbo.Companies");
            DropIndex("dbo.Acts", new[] { "CompanyID" });
            RenameColumn(table: "dbo.Acts", name: "CompanyID", newName: "Company_CompanyID");
            AddColumn("dbo.Acts", "Bid_BidID", c => c.Int());
            AddColumn("dbo.Acts", "ElectricMeter_ElectricMeterID", c => c.Int());
            AddColumn("dbo.Contracts", "Company_CompanyID", c => c.Int());
            AlterColumn("dbo.Acts", "Company_CompanyID", c => c.Int());
            CreateIndex("dbo.Acts", "Bid_BidID");
            CreateIndex("dbo.Acts", "Company_CompanyID");
            CreateIndex("dbo.Acts", "ElectricMeter_ElectricMeterID");
            CreateIndex("dbo.Contracts", "Company_CompanyID");
            AddForeignKey("dbo.Acts", "Bid_BidID", "dbo.Bids", "BidID");
            AddForeignKey("dbo.Acts", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters", "ElectricMeterID");
            AddForeignKey("dbo.Contracts", "Company_CompanyID", "dbo.Companies", "CompanyID");
            AddForeignKey("dbo.Acts", "Company_CompanyID", "dbo.Companies", "CompanyID");
            DropColumn("dbo.Acts", "ElectricMeterID");
            DropColumn("dbo.Acts", "BidID");
            DropColumn("dbo.Contracts", "CompanyID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "CompanyID", c => c.Int(nullable: false));
            AddColumn("dbo.Acts", "BidID", c => c.Int(nullable: false));
            AddColumn("dbo.Acts", "ElectricMeterID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Acts", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Contracts", "Company_CompanyID", "dbo.Companies");
            DropForeignKey("dbo.Acts", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters");
            DropForeignKey("dbo.Acts", "Bid_BidID", "dbo.Bids");
            DropIndex("dbo.Contracts", new[] { "Company_CompanyID" });
            DropIndex("dbo.Acts", new[] { "ElectricMeter_ElectricMeterID" });
            DropIndex("dbo.Acts", new[] { "Company_CompanyID" });
            DropIndex("dbo.Acts", new[] { "Bid_BidID" });
            AlterColumn("dbo.Acts", "Company_CompanyID", c => c.Int(nullable: false));
            DropColumn("dbo.Contracts", "Company_CompanyID");
            DropColumn("dbo.Acts", "ElectricMeter_ElectricMeterID");
            DropColumn("dbo.Acts", "Bid_BidID");
            RenameColumn(table: "dbo.Acts", name: "Company_CompanyID", newName: "CompanyID");
            CreateIndex("dbo.Acts", "CompanyID");
            AddForeignKey("dbo.Acts", "CompanyID", "dbo.Companies", "CompanyID", cascadeDelete: true);
        }
    }
}
