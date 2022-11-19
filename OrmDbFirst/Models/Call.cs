using System;
using System.Collections.Generic;

namespace OrmDbFirst.Models;

public partial class Call
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int? CallOutcomeId { get; set; }

    public virtual CallOutcome? CallOutcome { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
