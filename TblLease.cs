using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblLease
{
    public int LeaseId { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? ZipCode { get; set; }

    public string Tenant { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public float LeaseAmount { get; set; }
}
