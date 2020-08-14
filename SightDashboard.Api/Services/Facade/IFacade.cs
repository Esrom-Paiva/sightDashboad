using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Facade
{
    public interface IFacade
    {
        IEnumerable<OrderEntity> GetAllOrder();

        void SeedOrders(int nOrders);

        IEnumerable<CustomerEntity> GetAllCustomer();

        void SeedCustomers(int nCustomers);

        IEnumerable<ServerEntity> GetAllServer();

        void SeedServers();

    }
}
