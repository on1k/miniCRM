namespace miniCRM.Data
{
    using Entities;
    using Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyMainDbContext : DbContext
    {
        
        public MyMainDbContext()
            : base("name=MyMainDbContext")
        {
            //Database.SetInitializer<MyMainDbContext>(new BaseInitializer());
        }

        public IDbSet<Act> Acts { get; set; }
        public IDbSet<Bid> Bids { get; set; }
        public IDbSet<Company> Companys { get; set; }
        public IDbSet<Contract> Contracts { get; set; }
        public IDbSet<ElectricMeter> ElectricMeters { get; set; }
        public IDbSet<Employe> Employes { get; set; }

    }
}