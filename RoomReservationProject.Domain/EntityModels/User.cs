using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("Users")]
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string EncryptedPassword { get; set; }
        public DateTime ExpireDate { get; set; }
        public int BadLoginAttempts { get; set; }
        public string ActivationHash { get; set; }
    }
}
