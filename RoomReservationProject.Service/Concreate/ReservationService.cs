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
    public class ReservationService : Service<Reservation>, IReservationService
    {
        private readonly IReservationRepository _reservation;
        public ReservationService(IReservationRepository repository) :
       base(repository)
        {
            this._reservation = repository;
        }
        public ServiceResult<ReservationVM> AddReservation(ReservationVM reservation)
        {
            ServiceResult<ReservationVM> res = new ServiceResult<ReservationVM>();

            try
            {
                var reservationList = _reservation.GetAllAsync().Result.Where(x => x.RoomId == reservation.RoomId && x.Checkin >= reservation.Checkin && x.Checkout <= reservation.Checkout).ToList();
                if (reservationList == null)
                {
                    Reservation item = new Reservation()
                    {
                        RoomId = reservation.RoomId,
                        Checkin = reservation.Checkin,
                        Checkout = reservation.Checkout,
                        CustomerId = reservation.CustomerId,
                        HowManyPerson = reservation.HowManyPerson,
                        CreatedDate = DateTime.Now,
                        LastModifiedDate = DateTime.Now,
                        Totaldays = (reservation.Checkout - reservation.Checkin).Days,
                        CreatedById = 1,
                        ModifiedById = 1,
                        ReservationCost = (reservation.Checkout - reservation.Checkin).Days * 120, // deafult per days 120 currency

                    };
                    _reservation.AddAsync(item);
                    res.Result = reservation;
                    res.Ok();
                }
                else
                {
                    res.Fail();
                }

            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

        public ServiceResult<List<ReservationVM>> GetAllReservations()
        {
            ServiceResult<List<ReservationVM>> res = new ServiceResult<List<ReservationVM>>();

            var mappedList = new List<ReservationVM>() { };

            var reservations = _reservation.GetAllAsync().Result;
            foreach (var item in reservations)
            {
                mappedList.Add(new ReservationVM()
                {
                    Id = item.Id,
                    RoomId = item.RoomId,
                    Checkin = item.Checkin,
                    Checkout = item.Checkout,
                    CustomerId = item.CustomerId,
                    HowManyPerson = item.HowManyPerson,
                    Totaldays = (item.Checkout - item.Checkin).Days,
                    ReservationCost = (item.Checkout - item.Checkin).Days * 120, // deafult per days 120 currency
                    CustomerDesc = ""
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

        public ServiceResult<List<ReservationVM>> GetReservations(ReservationFilterModel filterModel)
        {
            ServiceResult<List<ReservationVM>> res = new ServiceResult<List<ReservationVM>>();

            var mappedList = new List<ReservationVM>() { };

            var reservations = _reservation.GetAllAsync().Result;

            if (filterModel.HowManyPerson != null)
            {
                reservations.Where(x => x.HowManyPerson == filterModel.HowManyPerson);
            }
            if (filterModel.RoomId != null)
            {
                reservations.Where(x => x.RoomId == filterModel.RoomId);
            }
            if (filterModel.CustomerId != null)
            {
                reservations.Where(x => x.CustomerId == filterModel.CustomerId);
            }
            if (filterModel.Checkin != null)
            {
                reservations.Where(x => x.Checkin == filterModel.Checkin);
            }
            if (filterModel.Checkout != null)
            {
                reservations.Where(x => x.Checkout == filterModel.Checkout);
            }

            foreach (var item in reservations)
            {
                mappedList.Add(new ReservationVM()
                {
                    Id = item.Id,
                    RoomId = item.RoomId,
                    Checkin = item.Checkin,
                    Checkout = item.Checkout,
                    CustomerId = item.CustomerId,
                    HowManyPerson = item.HowManyPerson,
                    Totaldays = (item.Checkout - item.Checkin).Days,
                    ReservationCost = (item.Checkout - item.Checkin).Days * 120, // deafult per days 120 currency
                    CustomerDesc = ""
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

        public ServiceResult<bool> RemoveReservation(int id)
        {
            ServiceResult<bool> res = new ServiceResult<bool>();
            var reservation = _reservation.GetByIdAsync(id).Result;
            try
            {
                _reservation.Remove(reservation);
                res.Result = true;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

        public ServiceResult<ReservationVM> UpdateReservation(ReservationVM reservation)
        {
            ServiceResult<ReservationVM> res = new ServiceResult<ReservationVM>();
            try
            {
                Reservation item = new Reservation()
                {
                    RoomId = reservation.RoomId,
                    Checkin = reservation.Checkin,
                    Checkout = reservation.Checkout,
                    CustomerId = reservation.CustomerId,
                    HowManyPerson = reservation.HowManyPerson,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now,
                    Totaldays = (reservation.Checkout - reservation.Checkin).Days,
                    CreatedById = 1,
                    ModifiedById = 1,
                    ReservationCost = (reservation.Checkout - reservation.Checkin).Days * 120, // deafult per days 120 currency


                };
                _reservation.Update(item);
                res.Result = reservation;
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
