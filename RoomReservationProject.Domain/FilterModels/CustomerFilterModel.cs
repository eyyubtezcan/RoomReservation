using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.FilterModels
{
    public class CustomerFilterModel
    {
        public int? CustomerId  { get; set; }
        //public bool? UnpaidBalance { get; set; }
        public CustomerFilterModel()
        {
            CustomerId = null;
          //  UnpaidBalance = null;

        }
    }
}
