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
    public class StateRepository: GenericRepository<State>, IState
    {
        private readonly PaolitaContext _context;

        public StateRepository(PaolitaContext context) : base(context)
        {
            _context = context;
        }
    public override async Task<IEnumerable<State>> GetAllAsync()
    {
        return await _context.States
            .Include(p => p.Cities)
            .ToListAsync();
    }

    public async Task<List<City>> GetCityByStateIdAsync(int stateId)
    {
        return await _context.Cities
        .Where(d => d.IdstateFk == stateId)
        .ToListAsync();
    }

    public async Task<State> GetByIdAsync2(int id)
    {
        return await _context.States
            .Include(p => p.Cities)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
    
}
}