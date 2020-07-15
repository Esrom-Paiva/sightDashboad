using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interface
{
    public interface IServerService
    {
        IEnumerable<Server> GetAll();
        public void SeedServers();
    }
}
