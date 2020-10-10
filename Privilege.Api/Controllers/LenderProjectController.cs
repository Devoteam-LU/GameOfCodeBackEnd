using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Privilege.Business.Models;
using Privilege.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Privilege.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class LenderProjectController : ControllerBase
    {
        public LenderProjectController(LenderProjectService lenderProjectService)
        {
            LenderProjectService = lenderProjectService;
        }

        private LenderProjectService LenderProjectService { get; }

        [HttpPut("Create")]
        public async Task<long> CreateAsync(ProjectDto projectDto)
        {
            return await LenderProjectService.CreateAsync(projectDto, User.Claims.First(c => c.Type == "UserID").Value);
        }

        [HttpPost("Update")]
        public async Task UpdateAsync(ProjectDto projectDto)
        {
            await LenderProjectService.UpdateAsync(projectDto);
        }

        [HttpGet("ListByUser")]
        public async Task<IEnumerable<ProjectDto>> ListByUserAsync()
        {
            return await LenderProjectService.ListByUserAsync(User.Claims.First(c => c.Type == "UserID").Value);
        }
    }
}
