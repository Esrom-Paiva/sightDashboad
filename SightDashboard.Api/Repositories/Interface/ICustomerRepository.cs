using Repositories.Entity;
using Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface ICustomerRepository: IBaseRepository<Customer>
    {
        int Count();
    }
}
