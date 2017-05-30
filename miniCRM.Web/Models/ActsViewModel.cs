using miniCRM.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miniCRM.Web.Models
{
    public class ActsViewModel
    {
        public IEnumerable<Act> Acts { get; set; } 
    }
}