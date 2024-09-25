using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblVacation
{
    public int VacationId { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public int? AutumnHigh { get; set; }

    public int? AutumnLow { get; set; }

    public int? Duration { get; set; }

    public float Price { get; set; }
}
