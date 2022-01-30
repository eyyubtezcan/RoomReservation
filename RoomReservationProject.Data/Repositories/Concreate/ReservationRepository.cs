using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Data.Repositories.Concreate
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {   
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }

    }
}
