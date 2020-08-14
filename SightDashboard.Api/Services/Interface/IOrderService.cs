using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Services.Interface
{
    public interface IOrderService
    {
        OrderEntity GetById(Expression<Func<Order, bool>> expression = null);
        IEnumerable<OrderEntity> GetAll();

        IEnumerable<OrderEntity> GetAll(params Expression<Func<Order, object>>[] includeExpressions);

        void SeedOrders(int nOrders);
    }
}
