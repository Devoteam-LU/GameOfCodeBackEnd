using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Privilege.Database.DatabaseModels;

namespace Privilege.Database
{
    public class PrivilegeDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public PrivilegeDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}