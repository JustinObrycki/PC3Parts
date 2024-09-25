using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblIncident
{
    public int IncidentId { get; set; }

    public DateTime? IncidentDate { get; set; }

    public int? ViolationId { get; set; }

    public int? Policeid { get; set; }

    public int? Driverid { get; set; }

    public virtual TblDriver? Driver { get; set; }

    public virtual TblPolice? Police { get; set; }

    public virtual TblViolation? Violation { get; set; }
}
