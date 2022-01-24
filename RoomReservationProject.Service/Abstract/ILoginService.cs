using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Abstract
{
    public interface ILoginService
    {
        //ServiceResult<User> Login(LoginVM model);
        ServiceResult<bool> IsLoggedIn(string token, string sessionId, int userId);
    }
}
