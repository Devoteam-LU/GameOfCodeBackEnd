using AutoMapper;
using Privilege.Database;

namespace Privilege.Business.Services.Abstracts
{
    public abstract class BaseService
    {
        public BaseService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
        {
            DbContext = privilegeDbContext;
            Mapper = mapper;
        }

        public PrivilegeDbContext DbContext { get; }
        public IMapper Mapper { get; }
    }
}