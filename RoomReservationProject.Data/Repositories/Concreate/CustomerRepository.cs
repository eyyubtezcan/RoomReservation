using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Data.Repositories.Concreate
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {   
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }

    }
}
