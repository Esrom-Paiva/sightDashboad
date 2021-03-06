﻿using Repositories.Interface;
using Repositories.Entity;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Repositories.UnitOfWork;
using Repositories.Context;
using System.Linq.Expressions;
using Entities.Entity;
using AutoMapper;

namespace Services.Service
{
    public class ServerService: IServerService
    {
        private IMapper _mapper;

        private readonly UnitOfWork _unitOfWork;

        public ServerService(BaseContext baseContext, IMapper mapper)
        {
            _unitOfWork = new UnitOfWork(baseContext);
            _mapper = mapper;
        }
        public ServerEntity GetById(Expression<Func<Server, bool>> expression = null)
        {
            return _mapper.Map<Server, ServerEntity>(_unitOfWork.ServerRepository.Get(expression));
        }

        public IEnumerable<ServerEntity> GetAll(Expression<Func<Server, bool>> expression = null)
        {
            return _mapper.Map<List<Server>, List<ServerEntity>>(_unitOfWork.ServerRepository.GetAll(expression));
        }

        public ServerEntity Put(int id, ServerMessage message)
        {
            var server = _unitOfWork.ServerRepository.Get(s => s.Id == id);

            if (server is null)
            {
                return null;
            }
            else 
            {
                server.IsOnline = message.Payload;

                _unitOfWork.ServerRepository.Put(server);

                _unitOfWork.Commit();

                return _mapper.Map<Server,ServerEntity>(server);
            }
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
