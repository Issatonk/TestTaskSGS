using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
