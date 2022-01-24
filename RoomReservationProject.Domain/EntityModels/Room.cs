using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.EntityModels
{
    [Table("Rooms")]
    public class Room: BaseEntity
    {
        public string DoorNumber { get; set; }
        public string Floor { get; set; }
        public string Name { get; set; }
        public int SingleBedQty { get; set; }
        public int DoubleBedQty { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasTV { get; set; }
        public bool HasAirCondition { get; set; }
        public string RoomSize { get; set; }
        public string Description { get; set; }
        public int RoomStatusId { get; set; }
        public decimal RoomCost{ get; set; }
        public int MaxOccupancy { get; set; }
       // public int? BlockId { get; set; } // if there are lot of block

    }
}
