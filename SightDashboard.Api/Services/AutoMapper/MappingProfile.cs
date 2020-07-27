using AutoMapper;
using Entities.Entity;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderEntity,Order>().ForMember(dest => dest.Id, act => act.Ignore()).ReverseMap();

            CreateMap<ServerEntity,Server>().ForMember(dest => dest.Id, act => act.Ignore()).ReverseMap();

            CreateMap<CustomerEntity,Customer>()
                .ForMember(dest => dest.Id, act => act.Ignore())
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email))
                .ForMember(dest => dest.state, act => act.MapFrom(src => src.State))
                .ReverseMap();
        }
    }
}
