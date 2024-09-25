using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblDriver
{
    public int DriverId { get; set; }

    public string? Dname { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? Dstate { get; set; }

    public string? Zip { get; set; }

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
