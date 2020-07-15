using Repositories.Context;
using Repositories.Interface;
using Repositories.Entity;
using System.Linq;

namespace Repositories.Repository
{
    public class CustomerRepository : BaseRepository<Customer>,ICustomerRepository
    {

        public CustomerRepository(BaseContext Db): base(Db)
        {

        }

        public int Count()
        {
            return GetAll().Count();
        }
    }
}
