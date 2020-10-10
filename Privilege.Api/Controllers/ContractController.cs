using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Privilege.Business.Models;
using Privilege.Business.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Privilege.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        public ContractController(ContractService contractService)
        {
            ContractService = contractService;
        }

        private ContractService ContractService { get; }

        [HttpGet("GetByIds/{borrowerProjectId}/{lenderProjectId}")]
        public async Task<IEnumerable<ContractDto>> GetByIdsAsync(long borrowerProjectId, long lenderProjectId)
        {
            return await ContractService.GetByIdsAsync(borrowerProjectId, lenderProjectId);
        }

        [HttpPut("Create")]
        public async Task<long> CreateAsync(ContractDto contractDto)
        {
            return await ContractService.CreateAsync(contractDto, User.Claims.First(c => c.Type == "UserID").Value);
        }

        [HttpPost("Update")]
        public async Task UpdateAsync(ContractDto contractDto)
        {
            await ContractService.UpdateAsync(contractDto);
        }

        [HttpDelete("Delete/{id}")]
        public async Task DeleteAsync(long id)
        {
            await ContractService.DeleteAsync(id);
        }
    }
}