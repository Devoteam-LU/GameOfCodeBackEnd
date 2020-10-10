using AutoMapper;
using Privilege.Business.Services.Abstracts;
using Privilege.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Privilege.Business.Services
{
    public class ContractService : BaseService
    {
        public ContractService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }
    }
}
