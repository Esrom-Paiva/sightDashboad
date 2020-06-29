using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        void SeedCustomers(int nCustomers);
    }
}
