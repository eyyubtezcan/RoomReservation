using Microsoft.AspNetCore.Mvc;
using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.ViewModels;
using RoomReservationProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservationProject.API.Controllers
{
    public class RoomController : BaseAuthorizeController
    {
        // private ILoggerManager _logger;
        IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        // GET: api/Room
        [HttpGet("GetRooms")]

        public async Task<IEnumerable<RoomVM>> GetRooms()
        {
            //var customers = await Task.FromResult(_RoomService.GetAllRooms().Result);


            //return customers;

            var rooms = _roomService.GetAllRooms();

            if (rooms.isOk)
            {
                var res = await Task.FromResult(rooms.Result);
                return res;
            }
            else
            {
                return null;
            }

        }
        // GET: api/Room
        [HttpGet("GetRoomStatues")]

        public async Task<IEnumerable<RoomStatus>> GetRoomStatues()
        {
            //var customers = await Task.FromResult(_RoomService.GetAllRooms().Result);


            //return customers;

            var rooms = _roomService.GetAllRoomStatues();

            if (rooms.isOk)
            {
                var res = await Task.FromResult(rooms.Result);
                return res;
            }
            else
            {
                return null;
            }

        }
        //GET: api/Room
        [HttpPost("AddRoom")]

        public async Task<ActionResult<RoomVM>> AddRooms(RoomVM customer)
        {
            var cst = _roomService.AddRoom(customer);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("UpdateRoom")]

        public async Task<ActionResult<RoomVM>> UpdateRoom(RoomVM customer)
        {
            var cst = _roomService.UpdateRoom(customer);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }
        //GET: api/Room
        [HttpPost("RemoveRoom")]

        public async Task<ActionResult<bool>> RemoveRoom(int id)
        {
            var cst = _roomService.RemoveRoom(id);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

    }
}
