using RoomReservationProject.Core.Abstract;
using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Data.UnitOfWorks;
using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.FilterModels;
using RoomReservationProject.Domain.ViewModels;
using RoomReservationProject.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Concreate
{
    public class RoomService : Service<Room>, IRoomService
    {
        private readonly IRoomRepository _room;
        private readonly IRepository<RoomStatus> _roomStatus;
        public RoomService(
            IRoomRepository repository,
            IRepository<RoomStatus> roomStatus
            ) :
       base(repository)
        {
            this._room = repository;
            this._roomStatus = roomStatus;

        }


        public ServiceResult<List<RoomVM>> GetAllRooms()
        {           
            ServiceResult<List<RoomVM>> res = new ServiceResult<List<RoomVM>>();
            var mappedList = new List<RoomVM>() { };

            var rooms = _room.GetAllAsync().Result;
           
            foreach (var item in rooms)
            {
                mappedList.Add(new RoomVM()
                {
                    Id = item.Id,
                    Description=item.Description,
                    DoorNumber=item.DoorNumber,
                    DoubleBedQty=item.DoubleBedQty,
                    Floor=item.Floor,
                    HasAirCondition=item.HasAirCondition,
                    HasBalcony=item.HasBalcony,
                    HasTV=item.HasTV,
                    MaxOccupancy=item.MaxOccupancy,
                    Name=item.Name,
                    RoomCost=item.RoomCost,
                    RoomSize=item.RoomSize,
                    RoomStatusId=item.RoomStatusId,
                    RoomStatusDesc= _roomStatus.GetByIdAsync(item.RoomStatusId).Result.Description,
                    SingleBedQty =item.SingleBedQty
                });
            }

            try
            {
                res.Result = mappedList.ToList();
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;

        }

        public ServiceResult<List<RoomStatus>> GetAllRoomStatues()
        {
            ServiceResult<List<RoomStatus>> res = new ServiceResult<List<RoomStatus>>();

            try
            {
                var list =_roomStatus.GetAllAsync().Result;

                res.Result = list.ToList();
                res.Ok();
                return res;

            }
            catch (Exception ex)
            {
                res.Fail();
            }
            return res;
        }
        public ServiceResult<RoomVM> AddRoom(RoomVM room)
        {
            ServiceResult<RoomVM> res = new ServiceResult<RoomVM>();
            try
            {
                Room item = new Room()
                {
                    Description = room.Description,
                    DoorNumber = room.DoorNumber,
                    DoubleBedQty = room.DoubleBedQty,
                    Floor = room.Floor,
                    HasAirCondition = room.HasAirCondition,
                    HasBalcony = room.HasBalcony,
                    HasTV = room.HasTV,
                    MaxOccupancy = room.MaxOccupancy,
                    Name = room.Name,
                    RoomCost = room.RoomCost,
                    RoomSize = room.RoomSize,
                    RoomStatusId = room.RoomStatusId,
                    SingleBedQty = room.SingleBedQty

                };
                _room.AddAsync(item);
                res.Result = room;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

        public ServiceResult<bool> RemoveRoom(int id)
        {
            ServiceResult<bool> res = new ServiceResult<bool>();
            var room = _room.GetByIdAsync(id).Result;
            try
            {
                _room.Remove(room);
                res.Result = true;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }
        public ServiceResult<List<RoomVM>> GetRooms(RoomFilterModel filterModel)
        {
            ServiceResult<List<RoomVM>> res = new ServiceResult<List<RoomVM>>();
            List<RoomVM> result = new List<RoomVM>() { };

            var rooms = _room.GetAllAsync().Result;

            if (filterModel != null)
            {
                if (filterModel.DoorNumber != null)
                {
                    rooms = rooms.Where(x => x.DoorNumber == filterModel.DoorNumber);
                }
                if (filterModel.Floor != null)
                {
                    rooms = rooms.Where(x => x.Floor == filterModel.Floor);
                }
                if (filterModel.SingleBedQty != null)
                {
                    rooms = rooms.Where(x => x.SingleBedQty == filterModel.SingleBedQty);
                }
                if (filterModel.DoubleBedQty != null)
                {
                    rooms = rooms.Where(x => x.DoubleBedQty == filterModel.DoubleBedQty);
                }
                if (filterModel.HasBalcony != null)
                {
                    rooms = rooms.Where(x => x.HasBalcony == filterModel.HasBalcony);
                }
                if (filterModel.HasTV != null)
                {
                    rooms = rooms.Where(x => x.HasTV == filterModel.HasTV);
                }
                if (filterModel.RoomSize != null)
                {
                    rooms = rooms.Where(x => x.RoomSize == filterModel.RoomSize);
                }
                if (filterModel.RoomStatusId != null)
                {
                    rooms = rooms.Where(x => x.RoomStatusId == filterModel.RoomStatusId);
                }
                if (filterModel.RoomCost != null)
                {
                    rooms = rooms.Where(x => x.RoomCost == filterModel.RoomCost);
                }
                if (filterModel.MaxOccupancy != null)
                {
                    rooms = rooms.Where(x => x.MaxOccupancy == filterModel.MaxOccupancy);
                }
            }
            foreach (var item in rooms)
            {
                result.Add(new RoomVM()
                {
                    Id = item.Id,
                    Description = item.Description,
                    DoorNumber = item.DoorNumber,
                    DoubleBedQty = item.DoubleBedQty,
                    Floor = item.Floor,
                    HasAirCondition = item.HasAirCondition,
                    HasBalcony = item.HasBalcony,
                    HasTV = item.HasTV,
                    MaxOccupancy = item.MaxOccupancy,
                    Name = item.Name,
                    RoomCost = item.RoomCost,
                    RoomSize = item.RoomSize,
                    RoomStatusId = item.RoomStatusId,
                    SingleBedQty = item.SingleBedQty
                });

                try
                {
                    res.Result = result;
                    res.Ok();
                }
                catch (Exception)
                {
                    res.Fail();
                }
             

            }
            return res;
        }

        public ServiceResult<RoomVM> UpdateRoom(RoomVM room)
        {
            ServiceResult<RoomVM> res = new ServiceResult<RoomVM>();
            try
            {
                Room item = new Room()
                {
                    Id = room.Id,
                    Description = room.Description,
                    DoorNumber = room.DoorNumber,
                    DoubleBedQty = room.DoubleBedQty,
                    Floor = room.Floor,
                    HasAirCondition = room.HasAirCondition,
                    HasBalcony = room.HasBalcony,
                    HasTV = room.HasTV,
                    MaxOccupancy = room.MaxOccupancy,
                    Name = room.Name,
                    RoomCost = room.RoomCost,
                    RoomSize = room.RoomSize,
                    RoomStatusId = room.RoomStatusId,
                    SingleBedQty = room.SingleBedQty

                };
                _room.Update(item);
                res.Result = room;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

     
    }
}
