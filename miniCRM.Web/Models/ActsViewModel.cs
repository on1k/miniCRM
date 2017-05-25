using miniCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniCRM.Web.Models
{
    public class ActsViewModel
    {
        public string NumberAct { get; set; }
        public Company Company { get; set; }
        public ElectricMeter ElectricMeter { get; set; }
        public DateTime ActualDate { get; set; }
        public decimal StartMeter { get; set; }
        public decimal EndMeter { get; set; }
        public Bid Bid { get; set; }
        public decimal Total { get; set; }
    }
}