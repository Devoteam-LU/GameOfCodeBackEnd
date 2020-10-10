using AutoMapper;
using Privilege.Business.Services.Abstracts;
using Privilege.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Privilege.Business.Services
{
    public class BorrowerProjectService : BaseService
    {
        public BorrowerProjectService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }
    }
}
