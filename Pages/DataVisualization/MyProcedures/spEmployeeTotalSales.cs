using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectObryckiJustin
{
    public class spEmployeeTotalSales
    {
        [Display(Name = "Employee Name")]
        public string? Employee { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Sales")]
        public double TotalSale { get; set; }
    }
}