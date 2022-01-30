using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("PaymentHistory")]
    public class PaymentHistory : BaseEntity
    {
        public string Description { get; set; }
        public string RoomId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public bool IsPaid { get; set; }
    }
}
