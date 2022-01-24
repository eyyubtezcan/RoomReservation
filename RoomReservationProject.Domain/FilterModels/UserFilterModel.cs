using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Domain.FilterModels
{
    public class UserFilterModel
    {
        public int? UserId  { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }

        public UserFilterModel()
        {
            UserId = null;
            RoleId = null;
            PermissionId = null;
            UserName = null;
            Email= null;

        }
    }
}
