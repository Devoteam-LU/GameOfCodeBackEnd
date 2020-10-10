using AutoMapper;
using Privilege.Business.Models;
using Privilege.Business.Models.Enum;
using Privilege.Database.DatabaseModels;

namespace Privilege.Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BorrowerProject, ProjectDto>()
                .ForMember(e => e.FirstName, m => m.MapFrom(s => s.User.FirstName))
                .ForMember(e => e.LastName, m => m.MapFrom(s => s.User.LastName))
                .ForMember(e => e.ProjectType, m => m.MapFrom(s => ProjectType.Borrow));
            CreateMap<ProjectDto, BorrowerProject>();

            CreateMap<LenderProject, ProjectDto>()
                .ForMember(e => e.FirstName, m => m.MapFrom(s => s.User.FirstName))
                .ForMember(e => e.LastName, m => m.MapFrom(s => s.User.LastName))
                .ForMember(e => e.ProjectType, m => m.MapFrom(s => ProjectType.Lend));
            CreateMap<ProjectDto, LenderProject>();
            CreateMap<Contract, ContractDto>().ReverseMap();
        }
    }
}