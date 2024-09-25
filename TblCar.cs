using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblCar
{
    public int CarId { get; set; }

    public string Make { get; set; } = null!;

    public string? Model { get; set; }

    public string CarYear { get; set; } = null!;

    public string? Color { get; set; }

    public string? LicensePlate { get; set; }

    public float? Cost { get; set; }

    public virtual ICollection<TblFaculty> TblFaculties { get; set; } = new List<TblFaculty>();

    public virtual ICollection<TblIncident2> TblIncident2s { get; set; } = new List<TblIncident2>();

    public virtual ICollection<TblStudent> TblStudents { get; set; } = new List<TblStudent>();
}
