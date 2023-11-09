using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        
        ICity Cities { get; }
        ICustomer Customers { get; }
        IState States { get; }
        IPersonType PersonsTypes { get; }
        ICountry Countries { get; }

        Task<int> SaveAsync();
    }
}
