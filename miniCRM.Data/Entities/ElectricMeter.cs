using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Data.Entities
{
    public class ElectricMeter
    {
        public int ElectricMeterID { get; set; }
        public string ModelName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime ExpDate { get; set; }
    }
}
