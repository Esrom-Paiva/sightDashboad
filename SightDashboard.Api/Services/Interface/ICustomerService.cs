using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>> expression = null);

        Customer GetById(Expression<Func<Customer, bool>> expression = null);

        void Save(CustomerEntity entity);

        void SeedCustomers(int nCustomers);
    }
}
