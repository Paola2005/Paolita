using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class Country:BaseEntity
{


    public string Name { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<State> States { get; set; }
}
