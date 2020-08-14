using Common.Helper;
using Repositories.Context;
using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using Repositories.UnitOfWork;
using System.Linq.Expressions;
using AutoMapper;
using Entities.Entity;

namespace Services.Service
{
    public class OrderService: IOrderService
    {
        private IMapper _mapper;

        private readonly UnitOfWork _unitOfWork;
        public OrderService(BaseContext baseContext, IMapper mapper)
        {
            _mapper = mapper;

            _unitOfWork = new UnitOfWork(baseContext);
        }

        public OrderEntity GetById(Expression<Func<Order, bool>> expression = null)
        {
           return _mapper.Map<Order, OrderEntity>(_unitOfWork.OrderRepository.Get(expression));
        }

        public IEnumerable<OrderEntity> GetAll()
        {
            return _mapper.Map<List<Order>, List<OrderEntity>>(_unitOfWork.OrderRepository.GetAll());
        }

        public IEnumerable<OrderEntity> GetAll(params Expression<Func<Order, object>>[] includeExpressions)
        {
            return _mapper.Map<List<Order>, List<OrderEntity>>(_unitOfWork.OrderRepository.GetAll(includeExpressions));

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
                    Customer = _unitOfWork.CustomerRepository.Get(c => c.Id == randCustomerId),
                    Total = Helpers.GetRandomOrderTotal(),
                    Placed = placed,
                    Completed = Completed
                });
            }
            return orders;
        }
    }
}
