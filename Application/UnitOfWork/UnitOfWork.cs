using Application.Repository;
using Domain.Data;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PaolitaContext _context;
    private ICity _city;
    private ICountry _country;
    private ICustomer _customer;
    private IPersonType _personType;
    private IState _state;

    public ICity Cities  {
        get
        {
            if (_city == null)
            {
                _city = new CityRepository(_context);
            }
            return _city;
        }
    }

    public ICustomer Customers  {
        get
        {
            if (_customer == null)
            {
                _customer = new CustomerRepository(_context);
            }
            return _customer;
        }
    }

    public IState States  {
        get
        {
            if (_state == null)
            {
                _state = new StateRepository(_context);
            }
            return _state;
        }
    }

    public IPersonType PersonsTypes  {
        get
        {
            if (_personType == null)
            {
                _personType = new PersonTypeRepository(_context);
            }
            return _personType;
        }
    }

    public ICountry Countries  {
        get
        {
            if (_country == null)
            {
                _country = new CountryRepository(_context);
            }
            return _country;
        }
    }

    public UnitOfWork(PaolitaContext context)
    {
        _context = context;
    }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
        _context.Dispose();
    }
}
