using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblViolation
{
    public int ViolationId { get; set; }

    public string? Violation { get; set; }

    public int? Fine { get; set; }

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
