using AutoMapper;
using Privilege.Business.Models;
using Privilege.Database.DatabaseModels;

namespace Privilege.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BorrowerProject, ProjectDto>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();
        }
    }
}