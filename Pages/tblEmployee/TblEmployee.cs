using System;
using System.Collections.Generic;
using ProjectObryckiJustin.Pages.tblOrder;

namespace ProjectObryckiJustin.Pages.tblEmployee;

public partial class TblEmployee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();
}
