using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        Order GetById(int Id);
        void Add(Order order);
        void Delete(int Id);
    }
}
