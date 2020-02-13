using System.Collections.Generic;
using AutoMapper;
using Budget.Core.Domain;
using Budget.Infrastructure.DTO;

namespace Budget.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<IEnumerable<User>, IEnumerable<UserDto>>();
            })
                .CreateMapper();
        
    }
}