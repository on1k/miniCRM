using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Data.Entities
{
    public class Bid
    {
        public int BidID { get; set; }
        public decimal Value { get; set; }
        public DateTime BidDate { get; set; }
    }
}
