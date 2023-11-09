using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class CountryRepository: GenericRepository<Country>, ICountry
    {
        private readonly PaolitaContext _context;

        public CountryRepository(PaolitaContext context) : base(context)
        {
            _context = context;
        }
    }
}