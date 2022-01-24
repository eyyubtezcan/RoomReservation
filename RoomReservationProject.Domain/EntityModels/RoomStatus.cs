using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("RoomStatus")]
    public class RoomStatus : BaseEntity
    {
        public string Description { get; set; }
    }
}
