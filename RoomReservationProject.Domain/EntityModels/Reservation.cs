using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.EntityModels
{
    public class Reservation: BaseEntity
    {
        public string CustomerId { get; set; }
        public int RoomId { get; set; }
        public int HowManyPerson { get; set; }
        public System.DateTime Checkin { get; set; }
        public System.DateTime Checkout { get; set; }
        public int? Totaldays { get; set; }
        public decimal ReservationCost { get; set; }
       
    }
}