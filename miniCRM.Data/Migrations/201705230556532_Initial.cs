namespace miniCRM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Acts",
                c => new
                    {
                        ActID = c.Int(nullable: false, identity: true),
                        CompanyID = c.Int(nullable: false),
                        ElectricMeterID = c.Int(nullable: false),
                        NumberAct = c.String(),
                        ActualDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StartMeter = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EndMeter = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActID)
                .ForeignKey("dbo.Companies", t => t.CompanyID, cascadeDelete: true)
                .Index(t => t.CompanyID);
            
            CreateTable(
                "dbo.Bids",
                c => new
                    {
                        BidID = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BidDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BidID);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyID = c.Int(nullable: false, identity: true),
                        ElectricMeterID = c.Int(nullable: false),
                        Name = c.String(),
                        EmployeName = c.String(),
                    })
                .PrimaryKey(t => t.CompanyID);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Period = c.DateTime(nullable: false),
                        CompanyID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContractID);
            
            CreateTable(
                "dbo.ElectricMeters",
                c => new
                    {
                        ElectricMeterID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        SerialNumber = c.String(),
                        ExpDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ElectricMeterID);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        EmployeID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeID);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.Acts", "CompanyID", "dbo.Companies");
            //DropIndex("dbo.Acts", new[] { "CompanyID" });
            //DropTable("dbo.Employes");
            //DropTable("dbo.ElectricMeters");
            //DropTable("dbo.Contracts");
            //DropTable("dbo.Companies");
            //DropTable("dbo.Bids");
            //DropTable("dbo.Acts");
        }
    }
}
