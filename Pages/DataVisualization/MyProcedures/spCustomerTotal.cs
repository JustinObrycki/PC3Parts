using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectObryckiJustin
{
    public class spCustomerTotal
    {
        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Spent")]
        public double TotalSpent { get; set; }
    }
}
