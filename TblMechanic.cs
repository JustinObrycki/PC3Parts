using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblMechanic
{
    public int MechanicNo { get; set; }

    public string? MechanicName { get; set; }

    public DateTime? ServiceDate { get; set; }

    public virtual ICollection<TblAutoClient> TblAutoClients { get; set; } = new List<TblAutoClient>();
}
