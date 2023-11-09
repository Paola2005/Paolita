using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Repository
{
    public class PersonTypeRepository: GenericRepository<PersonType>, IPersonType
    {
        private readonly PaolitaContext _context;

        public PersonTypeRepository(PaolitaContext context) : base(context)
        {
            _context = context;
        }
    }
}