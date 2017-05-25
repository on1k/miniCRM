namespace miniCRM.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using miniCRM.Data.Entities;

    public class Configuration : DbMigrationsConfiguration<MyMainDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyMainDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.ElectricMeters.AddOrUpdate(x => x.ElectricMeterID,
                new ElectricMeter { ElectricMeterID = 1, ModelName = "Меркурий", SerialNumber = "274382974", ExpDate = DateTime.Now.AddYears(5) },
                new ElectricMeter { ElectricMeterID = 2, ModelName = "СНПЧ", SerialNumber = "653244478", ExpDate = DateTime.Now.AddYears(5) },
                new ElectricMeter { ElectricMeterID = 3, ModelName = "Меркурий СН", SerialNumber = "449332004", ExpDate = DateTime.Now.AddYears(5) }
                );
            var meter1 = context.ElectricMeters.Find(2);
            var meter2 = context.ElectricMeters.Find(1);
            var meter3 = context.ElectricMeters.Find(3);
            context.Bids.AddOrUpdate(x => x.BidID,
                new Bid { BidID = 1, BidDate = DateTime.Now, Value = 3.75M}
                );
            context.Employes.AddOrUpdate(x => x.EmployeID,
                new Employe { EmployeID = 1, Name = "Андрей", FullName = "Козлов А.А."}
                );
            context.Companys.AddOrUpdate(x => x.CompanyID, 
                new Company { CompanyID = 1, Name = "ООО Стратосфера", EmployeName = "Сенчуков А.В.", ElectricMeter = meter1 },
                new Company { CompanyID = 2, Name = "ОАО Газмяс", EmployeName = "Иванов С.С.", ElectricMeter = meter2},
                new Company { CompanyID = 3, Name = "ЗАО Туттти", EmployeName = "Джонов С.И.", ElectricMeter = meter3}
                );
            var com1 = context.Companys.Find(1);
            var com2 = context.Companys.Find(2);
            var com3 = context.Companys.Find(3);

            context.Contracts.AddOrUpdate(x => x.ContractID, 
                new Contract { ContractID = 1, Name = "ДО-3245", Period = DateTime.Now.AddMonths(11), Company = com1 },
                new Contract { ContractID = 2, Name = "ДА-3289", Period = DateTime.Now.AddMonths(13), Company = com2 },
                new Contract { ContractID = 3, Name = "ДП-32221", Period = DateTime.Now.AddMonths(5), Company = com3 }
                );
            var bid1 = context.Bids.Find(1);

            var met1 = context.ElectricMeters.Find(1);
            var met2 = context.ElectricMeters.Find(2);
            var met3 = context.ElectricMeters.Find(3);

            context.Acts.AddOrUpdate(x => x.ActID, 
                new Act { ActID = 1, Bid = bid1, Company = com1, ElectricMeter = met2, NumberAct = "4325", StartMeter = 100, EndMeter = 150, ActualDate = DateTime.Now, Total = 50},
                new Act { ActID = 2, Bid = bid1, Company = com1, ElectricMeter = met2, NumberAct = "4326", StartMeter = 150, EndMeter = 270, ActualDate = DateTime.Now.AddMonths(1), Total = 120 },
                new Act { ActID = 3, Bid = bid1, Company = com1, ElectricMeter = met2, NumberAct = "4327", StartMeter = 270, EndMeter = 360, ActualDate = DateTime.Now.AddMonths(2), Total = 90 },
                new Act { ActID = 4, Bid = bid1, Company = com2, ElectricMeter = met1, NumberAct = "4328", StartMeter = 100, EndMeter = 150, ActualDate = DateTime.Now, Total = 50 },
                new Act { ActID = 5, Bid = bid1, Company = com2, ElectricMeter = met1, NumberAct = "4329", StartMeter = 150, EndMeter = 210, ActualDate = DateTime.Now.AddMonths(1), Total = 60 },
                new Act { ActID = 6, Bid = bid1, Company = com2, ElectricMeter = met1, NumberAct = "4330", StartMeter = 210, EndMeter = 350, ActualDate = DateTime.Now.AddMonths(2), Total = 140 },
                new Act { ActID = 7, Bid = bid1, Company = com2, ElectricMeter = met1, NumberAct = "4331", StartMeter = 350, EndMeter = 420, ActualDate = DateTime.Now.AddMonths(3), Total = 70 },
                new Act { ActID = 8, Bid = bid1, Company = com3, ElectricMeter = met3, NumberAct = "4332", StartMeter = 100, EndMeter = 190, ActualDate = DateTime.Now, Total = 90 },
                new Act { ActID = 9, Bid = bid1, Company = com3, ElectricMeter = met3, NumberAct = "4333", StartMeter = 190, EndMeter = 280, ActualDate = DateTime.Now.AddMonths(1), Total = 90 },
                new Act { ActID = 10, Bid = bid1, Company = com3, ElectricMeter = met3, NumberAct = "4334", StartMeter = 280, EndMeter = 330, ActualDate = DateTime.Now.AddMonths(2), Total = 50 }
                );
        }
    }
}
