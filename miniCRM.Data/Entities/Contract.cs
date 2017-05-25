using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Data.Entities
{
    public class Contract
    {
        public int ContractID { get; set; }
        public string Name { get; set; }
        public DateTime Period { get; set; }

        public Company Company { get; set; }
    }
}
