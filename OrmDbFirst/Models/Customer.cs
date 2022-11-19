using System;
using System.Collections.Generic;

namespace OrmDbFirst.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public int CityId { get; set; }

    public string CustomerAddress { get; set; } = null!;

    public DateTime? NextCallDate { get; set; }

    public DateTime TsInserted { get; set; }

    public virtual ICollection<Call> Calls { get; } = new List<Call>();
}
