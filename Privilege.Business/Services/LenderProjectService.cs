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
using System.Threading.Tasks;

namespace Privilege.Business.Services
{
    public class LenderProjectService : BaseService
    {
        public LenderProjectService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }

        public async Task<long> CreateAsync(ProjectDto projectDto, string value)
        {
            LenderProject lenderProject = Mapper.Map<LenderProject>(projectDto);
            lenderProject.CreationDate = DateTime.Now;
            lenderProject.CreatedByUserId = value;

            await DbContext.LenderProjects.AddAsync(lenderProject);

            return lenderProject.Id;
        }

        public async Task UpdateAsync(ProjectDto projectDto)
        {
            LenderProject lenderProject = await DbContext.LenderProjects.FirstOrDefaultAsync(b => b.Id == projectDto.Id);
            if (lenderProject != null)
            {
                lenderProject.Budget = projectDto.Budget;
                lenderProject.Description = projectDto.Description;
                lenderProject.Title = projectDto.Title;
                await DbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProjectDto>> ListByUserAsync(string value)
        {
            return await DbContext.LenderProjects.Where(e => e.CreatedByUserId == value).ProjectTo<ProjectDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
