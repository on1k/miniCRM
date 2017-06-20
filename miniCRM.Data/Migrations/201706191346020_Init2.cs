namespace miniCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Companies", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters");
            DropIndex("dbo.Companies", new[] { "ElectricMeter_ElectricMeterID" });
            RenameColumn(table: "dbo.Companies", name: "ElectricMeter_ElectricMeterID", newName: "ElectricMeterID");
            AlterColumn("dbo.Companies", "ElectricMeterID", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "ElectricMeterID");
            AddForeignKey("dbo.Companies", "ElectricMeterID", "dbo.ElectricMeters", "ElectricMeterID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ElectricMeterID", "dbo.ElectricMeters");
            DropIndex("dbo.Companies", new[] { "ElectricMeterID" });
            AlterColumn("dbo.Companies", "ElectricMeterID", c => c.Int());
            RenameColumn(table: "dbo.Companies", name: "ElectricMeterID", newName: "ElectricMeter_ElectricMeterID");
            CreateIndex("dbo.Companies", "ElectricMeter_ElectricMeterID");
            AddForeignKey("dbo.Companies", "ElectricMeter_ElectricMeterID", "dbo.ElectricMeters", "ElectricMeterID");
        }
    }
}
