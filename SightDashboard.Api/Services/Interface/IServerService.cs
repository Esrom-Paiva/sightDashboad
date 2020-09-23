using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Services.Interface
{
    public interface IServerService
    {
        ServerEntity GetById(Expression<Func<Server, bool>> expression = null);

        ServerEntity Put(int id, ServerMessage message);

        IEnumerable<ServerEntity> GetAll(Expression<Func<Server, bool>> expression = null);

        public void SeedServers();
    }
}
