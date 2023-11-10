using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Data;

namespace Application.Repository
{
    public class CityRepository : GenericRepository<City>, ICity
    {
        private readonly PaolitaContext _context;

        public CityRepository(PaolitaContext context) : base(context)
        {
            _context = context;
        }
        public  async Task<IEnumerable<City>> GetAllAsync2()
    {
        return await _context.Cities
            .Include(p => p.Customers)
            .ToListAsync();
    }
        public async Task<List<Customer>>GetCustomerByCityId(int cityId)
        {
            return await _context.Customers
            .Where(j=>j.IdcityFk==cityId)
            .ToListAsync();
        }
        public async Task<City>GetId(int id)
        {
            return await _context.Cities
            .Include(p=>p.Customers)
            .FirstOrDefaultAsync(p=>p.Id==id);
        }
    }
}