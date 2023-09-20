using Application.Mappings;
using AutoMapper;

namespace Application.Tests.Abstractions
{
    public abstract class HandlerTest
    {
        protected IMapper Mapper { get; }

        protected HandlerTest()
        {
            var cfg = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MappingProfile)));
            Mapper = cfg.CreateMapper();
        }
    }
}
