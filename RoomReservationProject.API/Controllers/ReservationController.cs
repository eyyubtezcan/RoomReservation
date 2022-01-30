using Microsoft.AspNetCore.Mvc;
using RoomReservationProject.Domain.ViewModels;
using RoomReservationProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservationProject.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReservationController : BaseAuthorizeController
    {
        // private ILoggerManager _logger;
        IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservation
        [HttpGet("GetReservations")]

        public async Task<IEnumerable<ReservationVM>> GetReservations()
        {
            var reservation = _reservationService.GetAllReservations();

            if (reservation.isOk)
            {
                var res = await Task.FromResult(reservation.Result);
                return res;
            }
            else
            {
                return null;
            }

        }
        //GET: api/reservation
        [HttpPost("AddReservation")]

        public async Task<ActionResult<ReservationVM>> AddReservation(ReservationVM reservation)
        {
            var rs = _reservationService.AddReservation(reservation);

            if (rs.isOk)
            {
                var res = await Task.FromResult(rs.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("UpdateReservation")]

        public async Task<ActionResult<ReservationVM>> UpdateReservation(ReservationVM reservation)
        {
            var rs = _reservationService.UpdateReservation(reservation);

            if (rs.isOk)
            {
                var res = await Task.FromResult(rs.Result);
                return res;
            }
            else
            {
                return null;
            }
        }
        //GET: api/Reservation
        [HttpPost("RemoveReservation")]

        public async Task<ActionResult<bool>> RemoveReservation(int id)
        {
            var rs = _reservationService.RemoveReservation(id);

            if (rs.isOk)
            {
                var res = await Task.FromResult(rs.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

    }
}
