using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblPolice
{
    public int PoliceId { get; set; }

    public string? Pname { get; set; }

    public virtual ICollection<TblIncident> TblIncidents { get; set; } = new List<TblIncident>();
}
