using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Privilege.Database.DatabaseModels;
using System.Linq;

namespace Privilege.Database
{
    public partial class PrivilegeDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public PrivilegeDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<BorrowerProject> BorrowerProjects { get; set; }
        public virtual DbSet<LenderProject> LenderProjects { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<UserInterest> UserInterests { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}