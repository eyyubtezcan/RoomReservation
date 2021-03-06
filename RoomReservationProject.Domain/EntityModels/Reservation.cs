using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("Reservation")]
    public class Reservation: BaseEntity
    {
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public int HowManyPerson { get; set; }
        public DateTime Checkin { get; set; }
        public DateTime Checkout { get; set; }
        public int? Totaldays { get; set; }
        public decimal ReservationCost { get; set; }
       
    }
}