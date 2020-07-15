using Repositories.Context;
using Repositories.Interface;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repository
{
    public class ServerRepository: BaseRepository<Server>, IServerRepository
    {
        public ServerRepository(BaseContext Db) : base(Db)
        {

        }
    }
}
