using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Facade
{
    public interface IFacade
    {
        IEnumerable<Order> GetAllOrder();

        void SeedOrders(int nOrders);

        IEnumerable<Customer> GetAllCustomer();

        void SeedCustomers(int nCustomers);

        IEnumerable<Server> GetAllServer();

        void SeedServers();

    }
}
