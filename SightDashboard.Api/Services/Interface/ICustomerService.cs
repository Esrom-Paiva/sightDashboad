using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface ICustomerService
    {
        IEnumerable<CustomerEntity> GetAll(Expression<Func<Customer, bool>> expression = null);

        CustomerEntity GetById(Expression<Func<Customer, bool>> expression = null);

        void Save(CustomerEntity entity);

        void SeedCustomers(int nCustomers);
    }
}
