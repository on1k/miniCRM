using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace miniCRM.Data.Entities
{
    public class ElectricMeter
    {
        public int ElectricMeterID { get; set; }
        [Display(Name = "Модель")]
        public string ModelName { get; set; }
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата окончания эксплуатации")]
        public DateTime ExpDate { get; set; }

        
    }
}
