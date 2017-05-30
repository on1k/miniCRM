using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Data.Entities
{
    public class Act
    {
        public int ActID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ElectricMeter ElectricMeter { get; set; }
        public string NumberAct { get; set; }
        public DateTime ActualDate { get; set; }
        public decimal Total { get; set; }
        public decimal StartMeter { get; set; }
        public decimal EndMeter { get; set; }
        public virtual Bid Bid { get; set; }
    }
}
