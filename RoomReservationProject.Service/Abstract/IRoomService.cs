using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.FilterModels;
using RoomReservationProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Abstract
{
    public interface IRoomService
    {
        ServiceResult<List<RoomVM>> GetAllRooms();
        ServiceResult<List<RoomStatus>> GetAllRoomStatues();
        // They will merge with 1 method

        #region They will merge with 1 method
        //CRUD
        ServiceResult<RoomVM> AddRoom(RoomVM room);
        ServiceResult<RoomVM> UpdateRoom(RoomVM room);
        ServiceResult<bool> RemoveRoom(int id);
        #endregion
        ServiceResult<List<RoomVM>> GetRooms(RoomFilterModel filterModel);
        


    }
}
