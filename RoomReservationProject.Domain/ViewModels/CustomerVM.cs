using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.ViewModels
{
    public class CustomerVM : BaseDomain
    {
        public string PassportNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } //Later will split with addresses entitymodel
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
