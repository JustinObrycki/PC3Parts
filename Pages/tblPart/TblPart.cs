using System;
using System.Collections.Generic;
using ProjectObryckiJustin.Pages.tblOrder;

namespace ProjectObryckiJustin.Pages.tblPart;

public partial class TblPart
{
    public int PartId { get; set; }

    public string? PartName { get; set; }

    public float? Cost { get; set; }

    public string? Color { get; set; }

    public string? PartDescription { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
