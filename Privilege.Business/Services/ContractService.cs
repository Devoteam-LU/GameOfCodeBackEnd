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

        public async Task DeleteAsync(long id)
        {
            Contract contract = await DbContext.Contracts.FirstOrDefaultAsync(e => e.Id == id);
            DbContext.Remove(contract);
            await DbContext.SaveChangesAsync();
        }
    }
}
