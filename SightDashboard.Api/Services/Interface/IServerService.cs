using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Interface
{
    public interface IServerService
    {
        IEnumerable<Server> GetAll(Expression<Func<Server, bool>> expression = null);
        public void SeedServers();
    }
}
