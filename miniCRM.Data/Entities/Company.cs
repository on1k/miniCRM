﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniCRM.Data.Entities
{
    public class Company
    {
        public int CompanyID { get; set; }
        public int ElectricMeterID { get; set; }
        public string Name { get; set; }
        public string EmployeName { get; set; }

        public ICollection<Act> Acts { get; set; }
        public virtual ElectricMeter ElectricMeter { get; set; }
    }
}
