﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class City:BaseEntity
{

    public string Name { get; set; } = null!;

    public int IdstateFk { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
    [JsonIgnore]
    public virtual State IdstateFkNavigation { get; set; } = null!;
}
