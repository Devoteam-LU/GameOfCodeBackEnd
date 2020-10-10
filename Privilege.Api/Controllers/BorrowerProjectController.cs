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
    public class BorrowerProjectController : ControllerBase
    {
        public BorrowerProjectController(BorrowerProjectService borrowerProjectService)
        {
            BorrowerProjectService = borrowerProjectService;
        }

        private BorrowerProjectService BorrowerProjectService { get; }

        [HttpPut("Create")]
        public async Task<long> CreateAsync(ProjectDto projectDto)
        {
            return await BorrowerProjectService.CreateAsync(projectDto, User.Claims.First(c => c.Type == "UserID").Value);
        }

        [HttpPost("Update")]
        public async Task UpdateAsync(ProjectDto projectDto)
        {
            await BorrowerProjectService.UpdateAsync(projectDto);
        }

        [HttpGet("ListByUser")]
        public async Task<IEnumerable<ProjectDto>> ListByUserAsync()
        {
            return await BorrowerProjectService.ListByUserAsync(User.Claims.First(c => c.Type == "UserID").Value);
        }
    }
}
