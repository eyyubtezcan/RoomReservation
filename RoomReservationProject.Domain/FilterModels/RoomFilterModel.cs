using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.FilterModels
{
    public class RoomFilterModel
    {
        public string DoorNumber { get; set; }
        public string Floor { get; set; }
        public int? SingleBedQty { get; set; }
        public int? DoubleBedQty { get; set; }
        public bool? HasBalcony { get; set; }
        public bool? HasTV { get; set; }
        public bool? HasAirCondition { get; set; }
        public string RoomSize { get; set; }     
        public int? RoomStatusId { get; set; }
        public decimal? RoomCost { get; set; }
        public int? MaxOccupancy { get; set; }
        //public bool? UnpaidBalance { get; set; }
        public RoomFilterModel()
        {
        

        }
    }
}
