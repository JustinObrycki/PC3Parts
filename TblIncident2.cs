using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblIncident2
{
    public int IncidentId { get; set; }

    public DateTime IncidentDate { get; set; }

    public int? StudentId { get; set; }

    public int? FacultyId { get; set; }

    public int PsafetyId { get; set; }

    public int? CarId { get; set; }

    public string? Comments { get; set; }

    public virtual TblCar? Car { get; set; }

    public virtual TblFaculty? Faculty { get; set; }

    public virtual TblPublicSafety Psafety { get; set; } = null!;

    public virtual TblStudent? Student { get; set; }
}
