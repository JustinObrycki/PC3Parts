using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblFaculty
{
    public int FacultyId { get; set; }

    public string FacName { get; set; } = null!;

    public string? FacGender { get; set; }

    public DateTime? HireDate { get; set; }

    public int? CarId { get; set; }

    public float? Salary { get; set; }

    public virtual TblCar? Car { get; set; }

    public virtual ICollection<TblIncident2> TblIncident2s { get; set; } = new List<TblIncident2>();
}
