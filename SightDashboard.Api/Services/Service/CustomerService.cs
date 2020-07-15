using Common.Helper;
using Repositories.Context;
using Repositories.Interface;
using Repositories.Entity;
using Repositories.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.UnitOfWork;

namespace Services.Service
{
    public class CustomerService: ICustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        public CustomerService(BaseContext baseContext)
        {
            _unitOfWork = new UnitOfWork(baseContext);
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _unitOfWork.CustomerRepository.GetAll();
            return customers;
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
