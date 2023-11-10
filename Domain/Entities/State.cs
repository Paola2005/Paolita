using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Domain.Entities;

public partial class State:BaseEntity
{


    public string Name { get; set; }

    public int IdcountryFk { get; set; }


    public virtual ICollection<City> Cities { get; set; }

    [JsonIgnore]
    public virtual Country IdcountryFkNavigation { get; set; }
}
