using System;
using System.Collections.Generic;

namespace OrmDbFirst.Models;

public partial class CallOutcome
{
    public int Id { get; set; }

    public string OutcomeText { get; set; } = null!;

    public virtual ICollection<Call> Calls { get; } = new List<Call>();
}
