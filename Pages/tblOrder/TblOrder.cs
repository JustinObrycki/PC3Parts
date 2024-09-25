using System;
using System.Collections.Generic;
using ProjectObryckiJustin.Pages.tblCustomer;
using ProjectObryckiJustin.Pages.tblEmployee;
using ProjectObryckiJustin.Pages.tblPart;

namespace ProjectObryckiJustin.Pages.tblOrder;

public partial class TblOrder
{
    public int OrderNo { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public int? PartId { get; set; }

    public int? Quantity { get; set; }

    public virtual TblCustomer? Customer { get; set; }

    public virtual TblEmployee? Employee { get; set; }

    public virtual TblPart? Part { get; set; }
}
