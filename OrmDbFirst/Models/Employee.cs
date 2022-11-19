using System;
using System.Collections.Generic;

namespace OrmDbFirst.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Call> Calls { get; } = new List<Call>();
}
