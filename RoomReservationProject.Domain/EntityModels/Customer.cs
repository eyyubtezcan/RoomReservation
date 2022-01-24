using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("Customers")]
    public class Customer: BaseEntity
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address{ get; set; } //Later will split with addresses entitymodel
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        
    }
}
