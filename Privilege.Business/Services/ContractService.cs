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
    public class ContractService : BaseService
    {
        public ContractService(PrivilegeDbContext privilegeDbContext, IMapper mapper)
            : base(privilegeDbContext, mapper)
        { }

        public async Task<IEnumerable<ContractDto>> GetByIdsAsync(long borrowerProjectId, long lenderProjectId)
        {
            return await DbContext.Contracts.Where(e => e.BorrowerProjectId == borrowerProjectId && e.LenderProjectId == lenderProjectId)
                .OrderByDescending(e => e.CreationDate).ProjectTo<ContractDto>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<long> CreateAsync(ContractDto contractDto, string userId)
        {
            Contract contract = Mapper.Map<Contract>(contractDto);
            contract.CreationDate = DateTime.Now;
            contract.CreatedByUserId = userId;

            await DbContext.Contracts.AddAsync(contract);

            return contract.Id;
        }

        public async Task UpdateAsync(ContractDto contractDto)
        {
            Contract contract = await DbContext.Contracts.FirstOrDefaultAsync(e => e.Id == contractDto.Id);
            contract.Amount = contractDto.Amount;
            contract.Clause = contractDto.Clause;
            contract.Expiration = contractDto.Expiration;
            contract.InterestRate = contractDto.InterestRate;

            await DbContext.SaveChangesAsync();
        }

        public async Task<UserBorrowLendSituationDto> UserSituationAsync(string userId)
        {
            return new UserBorrowLendSituationDto
            {
                TotalBorrowingAmount = await DbContext.Contracts.Where(c => c.CreatedByUserId == userId && c.LenderProjectId.HasValue).SumAsync(c => c.Amount),
                TotalBorrowingWithInterestRate = await DbContext.Contracts.Where(c => c.CreatedByUserId == userId && c.LenderProjectId.HasValue).SumAsync(c => c.Amount * (1 + c.InterestRate)),
                TotalLendingAmount = await DbContext.Contracts.Where(c => c.CreatedByUserId == userId && c.BorrowerProjectId.HasValue).SumAsync(c => c.Amount),
                TotalLendingWithInterestRate = await DbContext.Contracts.Where(c => c.CreatedByUserId == userId && c.BorrowerProjectId.HasValue).SumAsync(c => c.Amount * (1 + c.InterestRate)),
            };
        }

        public async Task<IEnumerable<ContractDto>> ListByUserIdAsync(string userId)
        {
            List<Contract> contracts = await DbContext.Contracts.Include(c => c.User).Include(c => c.BorrowerProject).Include(c => c.LenderProject).Where(c => c.CreatedByUserId == userId).OrderByDescending(c => c.CreationDate).ToListAsync();
            var result = Mapper.Map<List<ContractDto>>(contracts);
            result.ForEach(r =>
            {
                var contract = contracts.First(c => c.Id == r.Id);
                r.ProjectOwnerLastName = contract?.BorrowerProject?.User?.LastName ?? contract?.LenderProject?.User?.LastName;
                r.ProjectOwnerFirstName = contract?.BorrowerProject?.User?.FirstName ?? contract?.LenderProject?.User?.FirstName;
                r.ProjectTitle = contract?.BorrowerProject?.Title ?? contract?.LenderProject?.Title;
            });
            return result;
        }

        public async Task DeleteAsync(long id)
        {
            Contract contract = await DbContext.Contracts.FirstOrDefaultAsync(e => e.Id == id);
            DbContext.Remove(contract);
            await DbContext.SaveChangesAsync();
        }
    }
}
