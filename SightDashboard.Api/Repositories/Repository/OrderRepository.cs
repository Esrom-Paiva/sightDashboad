using Repositories.Context;
using Repositories.Interface;
using Repositories.Models;
using System.Collections.Generic;

namespace Repositories.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BaseContext _context;

        public OrderRepository(BaseContext baseContext)
        {
            _context = baseContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders;
        }
        public Order GetById(int Id)
        {
            return _context.Orders.Find(Id);
        }
        public void Add(Order customer)
        {
            _context.Add(customer);
        }

        public void Delete(int Id)
        {
            Order order = _context.Orders.Find(Id);
            _context.Orders.Remove(order);
        }
    }
}
