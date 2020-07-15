using Repositories.Context;
using Repositories.Interface;
using Repositories.Entity;
using System.Collections.Generic;

namespace Repositories.Repository
{
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    {

        public OrderRepository(BaseContext Db) : base(Db)
        {

        }
    }
}
