using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int Id);
        void Add(Customer customer);
        void Delete(int Id);
        int Count();
    }
}
