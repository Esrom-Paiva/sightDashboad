using System.Linq;
using Services.Interface;

namespace WebApi
{
    public class DataSeed
    {
        private IOrderService _orderService;
        private IServerService _serverService;
        private ICustomerService _customerService;

        public DataSeed(ICustomerService customerService, IOrderService orderService, IServerService serverService)
        {
            _orderService = orderService;
            _serverService = serverService;
            _customerService = customerService;
        }
        public void SeedData(int nCustomers, int nOrders)
        {
            var Orders = _orderService.GetAll();
            var Servers = _serverService.GetAll();
            var customers = _customerService.GetAll();

            if (!customers.Any())
            {
                _customerService.SeedCustomers(nCustomers);
            }
            if (!Orders.Any())
            {
                _orderService.SeedOrders(nOrders);
            }
            if (!Servers.Any())
            {
                _serverService.SeedServers();
            }
        }
    }
}
