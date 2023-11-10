using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IState:IGenericRepository<State>
    {
        Task<List<City>> GetCityByStateIdAsync(int stateId);
        Task<State> GetByIdAsync2(int id);
    }
}