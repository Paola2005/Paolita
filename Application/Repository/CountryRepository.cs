using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class CountryRepository: GenericRepository<Country>, ICountry
    {
        private readonly PaolitaContext _context;

        public CountryRepository(PaolitaContext context) : base(context)
        {
            _context = context;
        }
    public  async Task<IEnumerable<Country>> GetAllAsync1()
    {
        return await _context.Countries
            .Include(p => p.States)
            .ToListAsync();
    }
    public async Task<List<State>>GetStateByCountryIdAsync(int CountryId){
        return await _context.States
        .Where(i=>i.IdcountryFk==CountryId)
        .ToListAsync();
    }
    public async Task<Country>GetByIdAsync1(int id){
        return await _context.Countries
        .Include(p=>p.States)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    }
}