using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectObryckiJustin.Pages.DataVisualization.MyViews;

public partial class VwCustomerOrder
{
    [Display(Name = "First Name")]
    public string? FirstName { get; set; }
    [Display(Name = "Last Name")]
    public string? LastName { get; set; }
    [Display(Name = "Gender")]
    public string? Gender { get; set; }
    [Display(Name = "Part Name")]
    public string? PartName { get; set; }
    [Display(Name = "Type")]
    public string? Type { get; set; }
    [Display(Name = "Part Description")]
    public string? PartDescription { get; set; }
    [DisplayFormat(DataFormatString = "{0:C}")]
    [Display(Name = "Total Cost")]
    public float? TotalCost { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
    [Display(Name = "Order Date")]
    public DateTime? OrderDate { get; set; }
}
