using Repositories.Interface;
using Repositories.Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services.Service
{
    public class ServerService: IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ServerService(IServerRepository serverRepository, IUnitOfWork unitOfWork)
        {
            _serverRepository = serverRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Server> GetAll()
        {
            var servers = _serverRepository.GetAll().ToList();

            return servers;
        }

        public void SeedServers()
        {
            try
            {
                List<Server> servers = BuildServerList();

                foreach (var server in servers)
                {
                    _serverRepository.Add(server);
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
