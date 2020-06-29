using Repositories.Context;
using Repositories.Interface;
using Repositories.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repositories.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaseContext _context;

        public CustomerRepository(BaseContext baseContext)
        {
            _context = baseContext;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }
        public Customer GetById(int Id)
        {
            Customer customer = _context.Customers.Find(Id);

            return customer;
        }
        public void Add(Customer customer)
        {
            _context.Add(customer);
        }

        public void Delete(int Id)
        {
            Customer customer = _context.Customers.Find(Id);
            _context.Customers.Remove(customer);
        }
        public int Count()
        {
            return _context.Customers.Count();
        }
    }
}
