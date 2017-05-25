namespace miniCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "ElectricMeter_ElectricMeterID", c => c.Int());
            CreateIndex("dbo.Companies", "ElectricMeter_ElectricMeterID");
            AddForeignKey("dbo.Companies", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters", "ElectricMeterID");
            DropColumn("dbo.Companies", "ElectricMeterID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "ElectricMeterID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Companies", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters");
            DropIndex("dbo.Companies", new[] { "ElectricMeter_ElectricMeterID" });
            DropColumn("dbo.Companies", "ElectricMeter_ElectricMeterID");
        }
    }
}
