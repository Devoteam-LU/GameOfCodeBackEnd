using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Privilege.Business.Models;
using Privilege.Business.Services.Abstracts;
using Privilege.Database;
using Privilege.Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Privilege.Business.Services
{
    public class BorrowerProjectService : BaseService
    {
        public BorrowerProjectService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }

        public async Task<long> CreateAsync(ProjectDto projectDto, string value)
        {
            BorrowerProject borrowerProject = Mapper.Map<BorrowerProject>(projectDto);
            borrowerProject.CreationDate = DateTime.Now;
            borrowerProject.CreatedByUserId = value;

            await DbContext.BorrowerProjects.AddAsync(borrowerProject);

            return borrowerProject.Id;
        }

        public async Task UpdateAsync(ProjectDto projectDto)
        {
            BorrowerProject borrowerProject = await DbContext.BorrowerProjects.FirstOrDefaultAsync(b => b.Id == projectDto.Id);
            if (borrowerProject != null)
            {
                borrowerProject.Budget = projectDto.Budget;
                borrowerProject.Description = projectDto.Description;
                borrowerProject.Title = projectDto.Title;
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProjectDto>> ListByUserAsync(string value)
        {
            return await DbContext.BorrowerProjects.Where(e => e.CreatedByUserId == value).ProjectTo<ProjectDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
