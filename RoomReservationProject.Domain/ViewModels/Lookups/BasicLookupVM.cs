using RoomReservationProject.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.ViewModels.Lookups
{
    public class BasicLookupVM : BaseDomain
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
