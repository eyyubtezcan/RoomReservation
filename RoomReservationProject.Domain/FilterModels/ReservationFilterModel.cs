using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.FilterModels
{
    public class ReservationFilterModel
    {
        public int? CustomerId { get; set; }
        public int? RoomId { get; set; }
        public int? HowManyPerson { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public bool IsPaid { get; set; }
        public ReservationFilterModel()
        {
            CustomerId = null;
            IsPaid = false;

        }
    }
}
