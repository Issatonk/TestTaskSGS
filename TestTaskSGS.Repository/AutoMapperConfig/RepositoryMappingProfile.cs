using AutoMapper;
using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Repository.AutoMapperConfig
{
    public class RepositoryMappingProfile : Profile
    {
        public RepositoryMappingProfile()
        {
            CreateMap<Entity.CbrDaily, CbrDaily>();
            CreateMap<Entity.Valute, Valute>();
        }
    }
}
