using Repositories.Interface;
using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Repositories.UnitOfWork;
using Repositories.Context;

namespace Services.Service
{
    public class ServerService: IServerService
    {
        private readonly UnitOfWork _unitOfWork;

        public ServerService(BaseContext baseContext)
        {
            _unitOfWork = new UnitOfWork(baseContext);
        }

        public IEnumerable<Server> GetAll()
        {
            var servers = _unitOfWork.ServerRepository.GetAll();

            return servers;
        }

        public void SeedServers()
        {
            try
            {
                List<Server> servers = BuildServerList();

                foreach (var server in servers)
                {
                    _unitOfWork.ServerRepository.Add(server);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
            }
        }
        private List<Server> BuildServerList()
        {
            return new List<Server>
            {
                new Server
                {
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Dev-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Dev-Services",
                    IsOnline = true
                },

                new Server
                {
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "QA-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "QA-Services",
                    IsOnline = true
                },

                new Server
                {
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Prod-Mail",
                    IsOnline = true
                },
                new Server
                {
                    Name = "Prod-Services",
                    IsOnline = true
                },
            };
        }

    }
}
