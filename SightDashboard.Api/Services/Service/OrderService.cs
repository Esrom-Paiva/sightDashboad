using Common.Helper;
using Repositories.Context;
using Repositories.Interface;
using Repositories.Entity;
using Repositories.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.UnitOfWork;

namespace Services.Service
{
    public class OrderService: IOrderService
    {
        private readonly UnitOfWork _unitOfWork;
        public OrderService(BaseContext baseContext)
        {

            _unitOfWork = new UnitOfWork(baseContext);
        }

        public IEnumerable<Order> GetAll()
        {
            var order = _unitOfWork.OrderRepository.GetAll();

            return order;
        }

        public void SeedOrders(int nOrders)
        {
            try
            {
                List<Order> orders = BuildOrderList(nOrders);

                foreach (var order in orders)
                {
                    _unitOfWork.OrderRepository.Add(order);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
            }
        }

        private List<Order> BuildOrderList(int nOrders)
        {
            var orders = new List<Order>();
            var rand = new Random();
            for (int i = 1; i < nOrders; i++)
            {
                var placed = Helpers.GetRandomOrderPlaced();
                var Completed = Helpers.GetRandomOrderCompleted(placed);
                int randCustomerId = rand.Next(1, _unitOfWork.CustomerRepository.Count());
                orders.Add(new Order
                {
                    Customer = _unitOfWork.CustomerRepository.GetById(c => c.Id == randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = Completed
                });
            }
            return orders;
        }
    }
}
