using System;
using System.Collections.Generic;

namespace ProjectObryckiJustin;

public partial class TblStudent
{
    public int StudentId { get; set; }

    public string FName { get; set; } = null!;

    public string LName { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public string? Gender { get; set; }

    public string? Major { get; set; }

    public int CarId { get; set; }

    public virtual TblCar Car { get; set; } = null!;

    public virtual ICollection<TblIncident2> TblIncident2s { get; set; } = new List<TblIncident2>();
}
