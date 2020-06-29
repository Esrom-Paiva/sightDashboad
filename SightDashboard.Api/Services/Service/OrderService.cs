using Common.Helper;
using Repositories.Context;
using Repositories.Interface;
using Repositories.Models;
using Repositories.Repository;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services.Service
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Order> GetAll()
        {
            var order = _orderRepository.GetAll().ToList();

            return order;
        }

        public void SeedOrders(int nOrders)
        {
            try
            {
                List<Order> orders = BuildOrderList(nOrders);

                foreach (var order in orders)
                {
                    _orderRepository.Add(order);
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
                int randCustomerId = rand.Next(1,_customerRepository.Count());
                orders.Add(new Order
                {
                    Customer = _customerRepository.GetById(randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = Completed
                });
            }
            return orders;
        }
    }
}
