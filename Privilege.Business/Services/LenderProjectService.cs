using AutoMapper;
using Privilege.Business.Services.Abstracts;
using Privilege.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Privilege.Business.Services
{
    public class LenderProjectService : BaseService
    {
        public LenderProjectService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }
    }
}
