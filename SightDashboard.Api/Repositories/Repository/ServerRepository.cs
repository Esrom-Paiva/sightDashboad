using Repositories.Context;
using Repositories.Interface;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repository
{
    public class ServerRepository: IServerRepository
    {
        private readonly BaseContext _context;
        public ServerRepository(BaseContext baseContext)
        {
            _context = baseContext;
        }

        public IEnumerable<Server> GetAll()
        {
            return _context.Servers;
        }
        public Server GetById(int Id)
        {
            return _context.Servers.Find(Id);
        }
        public void Add(Server server)
        {
            _context.Add(server);
        }

        public void Delete(int Id)
        {
            Server server = _context.Servers.Find(Id);
            _context.Servers.Remove(server);
        }
    }
}
