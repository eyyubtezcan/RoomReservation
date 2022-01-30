using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.FilterModels;
using RoomReservationProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Abstract
{
    public interface IReservationService
    {
        ServiceResult<List<ReservationVM>> GetAllReservations();
        // They will merge with 1 method

        #region They will merge with 1 method
        //CRUD
        ServiceResult<ReservationVM> AddReservation(ReservationVM reservation);
        ServiceResult<ReservationVM> UpdateReservation(ReservationVM reservation);
        ServiceResult<bool> RemoveReservation(int id);
        #endregion
        ServiceResult<List<ReservationVM>> GetReservations(ReservationFilterModel filterModel);
        


    }
}
