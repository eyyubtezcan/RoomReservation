using RoomReservationProject.Core.Abstract;
using RoomReservationProject.Data.Repositories.Abstract;
using RoomReservationProject.Data.UnitOfWorks;
using RoomReservationProject.Domain.EntityModels;
using RoomReservationProject.Domain.FilterModels;
using RoomReservationProject.Domain.ViewModels;
using RoomReservationProject.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservationProject.Service.Concreate
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customer;
        public CustomerService(ICustomerRepository repository) :
       base(repository)
        {
            this._customer = repository;
        }


        public ServiceResult<List<CustomerVM>> GetAllCustomers()
        {           
            ServiceResult<List<CustomerVM>> res = new ServiceResult<List<CustomerVM>>();
            var mappedList = new List<CustomerVM>() { };

            var customers = _customer.GetAllAsync().Result;
            foreach (var item in customers)
            {
                mappedList.Add(new CustomerVM()
                {
                    Id = item.Id,
                    PassportNumber = item.PassportNumber,
                    Address = item.Address,
                    Email = item.Email,
                    Name = item.Name,
                    Surname = item.Surname,
                    PhoneNumber = item.PhoneNumber,
                    City = item.City,
                    Country = item.Country
                });
            }

            try
            {
                res.Result = mappedList.ToList();
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;

        }
        public ServiceResult<CustomerVM> AddCustomer(CustomerVM customer)
        {
            ServiceResult<CustomerVM> res = new ServiceResult<CustomerVM>();
            try
            {
                Customer item = new Customer()
                {
                    PassportNumber = customer.PassportNumber,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    City = customer.City,
                    Country = customer.Country
                    
                };
                _customer.AddAsync(item);
                res.Result = customer;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

        public ServiceResult<bool> RemoveCustomer(int id)
        {
            ServiceResult<bool> res = new ServiceResult<bool>();
            var customer = _customer.GetByIdAsync(id).Result;
            try
            {
                _customer.Remove(customer);
                res.Result = true;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }
        public ServiceResult<List<CustomerVM>> GetCustumers(CustomerFilterModel filterModel)
        {
            ServiceResult<List<CustomerVM>> res = new ServiceResult<List<CustomerVM>>();
            List<CustomerVM> result = new List<CustomerVM>() { };

            var customers = _customer.GetAllAsync().Result;

            if(filterModel != null)
            {
                if(filterModel.CustomerId!=null)
                {
                    customers = customers.Where(x => x.Id == filterModel.CustomerId);
                }
            }
            foreach (var item in customers)
            {
                result.Add(new CustomerVM()
                {
                    Id = item.Id,
                    PassportNumber = item.PassportNumber,
                    Address = item.Address,
                    Email = item.Email,
                    Name = item.Name,
                    Surname = item.Surname,
                    PhoneNumber = item.PhoneNumber,
                });
            }

            try
            {
                res.Result = result;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;

        }

        public ServiceResult<CustomerVM> UpdateCustomer(CustomerVM customer)
        {
            ServiceResult<CustomerVM> res = new ServiceResult<CustomerVM>();
            try
            {
                Customer item = new Customer()
                {
                    Id=customer.Id,
                    PassportNumber = customer.PassportNumber,
                    Name = customer.Name,
                    Surname = customer.Surname,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNumber,
                    Address = customer.Address,
                    City = customer.City,
                    Country = customer.Country,
                    State=customer.State

                };
                _customer.Update(item);
                res.Result = customer;
                res.Ok();
            }
            catch (Exception)
            {
                res.Fail();
            }
            return res;
        }

     
    }
}
