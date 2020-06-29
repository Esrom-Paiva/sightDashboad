using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interface
{
    public interface IServerRepository
    {
        IEnumerable<Server> GetAll();
        Server GetById(int Id);
        void Add(Server server);
        void Delete(int Id);
    }
}
