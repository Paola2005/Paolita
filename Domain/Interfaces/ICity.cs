using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICity:IGenericRepository<City>
    {
        Task<List<Customer>>GetCustomerByCityId(int cityId);
        Task<City>GetId(int id);
        Task<IEnumerable<City>> GetAllAsync2();
    }
}