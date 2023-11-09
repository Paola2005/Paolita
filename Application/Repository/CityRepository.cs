using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
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
    }
}