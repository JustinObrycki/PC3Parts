using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblAutoClient
{
    public int CustNo { get; set; }

    public string? CustName { get; set; }

    public int? Balance { get; set; }

    public int? MechanicNo { get; set; }

    public virtual TblMechanic? MechanicNoNavigation { get; set; }
}
