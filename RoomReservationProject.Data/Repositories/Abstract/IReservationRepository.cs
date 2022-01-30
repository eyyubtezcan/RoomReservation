using RoomReservationProject.Core.Abstract;
using RoomReservationProject.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoomReservationProject.Data.Repositories.Abstract
{
    public interface IReservationRepository : IRepository<Reservation>
    {
    }
}
