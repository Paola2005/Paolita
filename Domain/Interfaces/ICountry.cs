using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICountry:IGenericRepository<Country>
    {
        Task<IEnumerable<Country>> GetAllAsync1();
        Task<List<State>>GetStateByCountryIdAsync(int CountryId);
        Task<Country>GetByIdAsync1(int id);
    }
}