using RoomReservationProject.Data.Repositories;
using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Domain.EntityModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Data.UnitOfWorks
{
    public interface IUnitOfWork :IDisposable
    {
        Task CommitAsync();
        void Commit();

    }
}
