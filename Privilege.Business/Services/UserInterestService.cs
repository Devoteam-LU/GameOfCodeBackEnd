using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Privilege.Business.Models;
using Privilege.Business.Services.Abstracts;
using Privilege.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Privilege.Business.Services
{
    public class UserInterestService : BaseService
    {
        public UserInterestService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        {

        }

        public async Task<IEnumerable<string>> ListByUserId(string userId)
        {
            return await DbContext.UserInterests.Where(e => e.CreatedByUserId == userId).Select(e => e.Interest).OrderBy(e => e).Distinct().ToListAsync();
        }

        public async Task<IEnumerable<ProjectDto>> ListInterestingProjects(string userId)
        {
            IEnumerable<ProjectDto> result = null;
            IEnumerable<string> interests = await ListByUserId(userId);
            if (interests.Any())
            {
                IEnumerable<string> interestingUserIds = await DbContext.UserInterests.Where(e => e.CreatedByUserId != userId && interests.Contains(e.Interest)).Select(e => e.CreatedByUserId).Distinct().ToListAsync();
                IEnumerable<ProjectDto> borrowers = await DbContext.BorrowerProjects.Where(p => interestingUserIds.Contains(p.CreatedByUserId)).ProjectTo<ProjectDto>(Mapper.ConfigurationProvider).ToListAsync();
                IEnumerable<ProjectDto> lenders = await DbContext.LenderProjects.Where(p => interestingUserIds.Contains(p.CreatedByUserId)).ProjectTo<ProjectDto>(Mapper.ConfigurationProvider).ToListAsync();
                result = borrowers.Concat(lenders).OrderByDescending(p => p.CreationDate);
            }

            return result;
        }

        public async Task<IEnumerable<UserDto>> ListInterestingPeopleByUserId(string userId)
        {
            IEnumerable<UserDto> result = null;
            IEnumerable<string> interests = await ListByUserId(userId);
            if (interests.Any())
            {
                IEnumerable<string> interestingUserIds = await DbContext.UserInterests.Where(e => e.CreatedByUserId != userId && interests.Contains(e.Interest)).Select(e => e.CreatedByUserId).Distinct().ToListAsync();

                result = await DbContext.Users.Where(u => interestingUserIds.Contains(u.Id)).Select(u => new UserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Id = u.Id,
                    Interests = u.UserInterests.Select(ui => ui.Interest)
                }).ToListAsync();
            }
            return result;
        }
    }
}
