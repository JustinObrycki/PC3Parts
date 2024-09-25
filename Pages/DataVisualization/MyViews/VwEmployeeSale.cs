using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectObryckiJustin.Pages.DataVisualization.MyViews;

public partial class VwEmployeeSale
{
    [Display(Name = "Employee Name")]
    public string? Employee { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    [Display(Name = "Date of Sale")]
    public DateTime? DateOfSale { get; set; }
    [Display(Name = "Part Sold")]
    public string? PartSold { get; set; }
    [Display(Name = "Quantity Sold")]
    public int? QuantitySold { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Part Cost")]
    public float? PartCost { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Total Sale")]
    public float? TotalSale { get; set; }
    [Display(Name = "Type")]
    public string? Type { get; set; }
}
