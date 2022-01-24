using Microsoft.AspNetCore.Mvc;
using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.ViewModels;
using RoomReservationProject.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomReservationProject.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class CustomerController : BaseAuthorizeController
    {
        // private ILoggerManager _logger;
        ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/Customer
        [HttpGet("GetCustomers")]

        public async Task<IEnumerable<CustomerVM>> GetCustomers()
        {
            //var customers = await Task.FromResult(_CustomerService.GetAllCustomers().Result);


            //return customers;

            var customers = _customerService.GetAllCustomers();

            if (customers.isOk)
            {
                var res = await Task.FromResult(customers.Result);
                return res;
            }
            else
            {
                return null;
            }

        }
        //GET: api/Customer
       [HttpPost("AddCustomer")]

        public async Task<ActionResult<CustomerVM>> AddCustomers(CustomerVM customer)
        {
            var cst = _customerService.AddCustomer(customer);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

        [HttpPost("UpdateCustomer")]

        public async Task<ActionResult<CustomerVM>> UpdateCustomer(CustomerVM customer)
        {
            var cst = _customerService.UpdateCustomer(customer);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }
        //GET: api/Customer
        [HttpPost("RemoveCustomer")]

        public async Task<ActionResult<bool>> RemoveCustomer(int id)
        {
            var cst = _customerService.RemoveCustomer(id);

            if (cst.isOk)
            {
                var res = await Task.FromResult(cst.Result);
                return res;
            }
            else
            {
                return null;
            }
        }

    }
}

