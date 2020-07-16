using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Facade
{
    public class Facade : IFacade
    {
        private IOrderService _orderService;

        private IServerService _serverService;

        private ICustomerService _customerService;

        public Facade(IOrderService orderService, IServerService serverService, ICustomerService customerService)
        {
            _orderService = orderService;

            _serverService = serverService;

            _customerService = customerService;
        }

        public IEnumerable<Order> GetAllOrder()
        {
           return _orderService.GetAll();
        }

        public void SeedOrders(int nOrders)
        {
            _orderService.SeedOrders(nOrders);
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerService.GetAll();
        }

        public void SeedCustomers(int nCustomers)
        {
            _customerService.SeedCustomers(nCustomers);
        }

        public IEnumerable<Server> GetAllServer()
        {
            return _serverService.GetAll();
        }

        public void SeedServers()
        {
            _serverService.SeedServers();
        }
    }
}
