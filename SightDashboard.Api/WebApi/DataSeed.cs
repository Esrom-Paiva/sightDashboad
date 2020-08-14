using System.Linq;
using Services.Facade;


namespace WebApi
{
    public class DataSeed
    {
        private IFacade _facade;

        public DataSeed(IFacade facade)
        {
            _facade = facade;
        }
        public void CallSeedData()
        {
            SeedData(20, 1000);
        }


        private void SeedData(int nCustomers, int nOrders)
        {

            if (!_facade.GetAllCustomer().Any())
                _facade.SeedCustomers(nCustomers);
            
            if (!_facade.GetAllOrder().Any())
                _facade.SeedOrders(nOrders);

            if (!_facade.GetAllServer().Any())
                _facade.SeedServers();
        }
    }
}
