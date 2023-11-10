using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace API.Dto
{
    public class StateDto
    {
    public int Id { get; set; }

    public string Name { get; set; }
    public int IdcountryFk { get; set; }
    public  List<CityDto> Cities { get; set; }
    }
}