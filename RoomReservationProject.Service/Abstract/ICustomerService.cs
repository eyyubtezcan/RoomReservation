using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.FilterModels;
using RoomReservationProject.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Abstract
{
    public interface ICustomerService
    {
        ServiceResult<List<CustomerVM>> GetAllCustomers();
        // They will merge with 1 method
        
        #region They will merge with 1 method
        //CRUD
        ServiceResult<CustomerVM> AddCustomer(CustomerVM customer);
        ServiceResult<CustomerVM> UpdateCustomer(CustomerVM customer);
        ServiceResult<bool> RemoveCustomer(int id);
        #endregion
        ServiceResult<List<CustomerVM>> GetCustumers(CustomerFilterModel filterModel);
        


    }
}
