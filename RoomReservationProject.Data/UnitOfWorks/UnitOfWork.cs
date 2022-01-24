using RoomReservationProject.Core.Abstract;
using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Data.Repositories.Concreate;
using RoomReservationProject.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Repository<Customer> _customerRepository;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public Repository<Customer> CustomerRepository
        {
            get
            {

                if (_customerRepository == null)
                {
                    _customerRepository = new Repository<Customer>(_context);
                }
                return _customerRepository;
            }
        }

       

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
