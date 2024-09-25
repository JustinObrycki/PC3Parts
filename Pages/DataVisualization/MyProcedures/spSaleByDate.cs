using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectObryckiJustin
{
    public class spSaleByDate
    {
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Part Name")]
        public string? PartName { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Total Cost")]
        public float TotalCost { get; set; }
        [Display(Name = "Quantity Sold")]
        public int Quantity { get; set; }
        [Display(Name = "Employee Name")]
        public string? Employee { get; set; }
        [Display(Name = "Customer Name")]
        public string? Customer { get; set; }


    }
}