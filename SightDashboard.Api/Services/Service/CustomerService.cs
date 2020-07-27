using Common.Helper;
using Repositories.Context;
using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using Repositories.UnitOfWork;
using System.Linq.Expressions;
using Entities.Entity;
using AutoMapper;
using Services.Exceptions;
using System.Net;

namespace Services.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;

        private IMapper _mapper;

        public CustomerService(BaseContext baseContext, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = new UnitOfWork(baseContext);
        }

        public Customer GetById(Expression<Func<Customer, bool>> expression = null)
        {
            return _unitOfWork.CustomerRepository.GetById(expression);
        }

        public void Save(CustomerEntity entity)
        {
            try
            {
                _unitOfWork.CustomerRepository.Add(_mapper.Map<CustomerEntity, Customer>(entity));
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new CustomExceptions(ex.Message, ex.InnerException, HttpStatusCode.InternalServerError);
            }
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> expression = null)
        {
            return _unitOfWork.CustomerRepository.GetAll(expression);
        }

        public void SeedCustomers(int nCustomers)
        {
            try
            {
                List<Customer> customers = BuildCustomerList(nCustomers);

                foreach (var customer in customers)
                {
                    _unitOfWork.CustomerRepository.Add(customer);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {

                _unitOfWork.RollBack();
            }
        }

        private List<Customer> BuildCustomerList(int nCustomers)
        {
            var customers = new List<Customer>();
            var names = new List<string>();
            for (int i = 0; i < nCustomers; i++)
            {
                var name = Helpers.MakeUniqueCustomerName(names);
                customers.Add(new Customer
                {
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    state = Helpers.MakeCustomerState(),
                });
            }

            return customers;
        }
    }
}
