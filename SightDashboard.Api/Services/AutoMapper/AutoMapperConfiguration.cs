using AutoMapper;

namespace Services.AutoMapper
{
    public class AutoMapperConfiguration
    {
        private static IMapper _mapper;

        public static IMapper RegisterMappings()
        {
            var config = new MapperConfiguration(cfg => cfg.AddMaps("Services"));
            return config.CreateMapper();
        }

        public static IMapper GetMapper()
        {
            if (_mapper == null)
                Initialize();

            return _mapper;
        }

        public static void Initialize()
        {
            _mapper = _mapper ?? RegisterMappings();
        }

    }
}
