using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface IOrderService
    {
        IEnumerable<OrderEntity> GetAll();
        IEnumerable<OrderEntity> GetAll(params Expression<Func<Order, object>>[] includeExpressions);
        void SeedOrders(int nOrders);
    }
}
