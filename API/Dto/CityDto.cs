using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Dto
{
    public class CityDto
    {
    public int Id{get; set;}
   
    public string Name { get; set; } 
    public int IdstateFk { get; set; }
    public List<CustomerDto> Customers { get; set; }
    }
}