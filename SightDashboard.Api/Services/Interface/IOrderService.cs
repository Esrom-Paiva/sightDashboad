using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        void SeedOrders(int nOrders);
    }
}
