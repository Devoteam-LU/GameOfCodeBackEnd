using Microsoft.AspNetCore.Mvc;
using Privilege.Business.Models;
using Privilege.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Privilege.Api.Controllers
{
    public class UserInterestController : ControllerBase
    {
        public UserInterestController(UserInterestService userInterestService)
        {
            UserInterestService = userInterestService;
        }

        public UserInterestService UserInterestService { get; }

        [HttpGet("ListByUserId")]
        public async Task<IEnumerable<string>> ListByUserId()
        {
            return await UserInterestService.ListByUserId(User.Claims.First(c => c.Type == "UserID").Value);
        }

        [HttpGet("ListInterestingProjectsByUserId")]
        public async Task<IEnumerable<ProjectDto>> ListInterestingProjects()
        {
            return await UserInterestService.ListInterestingProjects(User.Claims.First(c => c.Type == "UserID").Value);
        }

        [HttpGet("ListInterestingPeopleByUserId")]
        public async Task<IEnumerable<UserDto>> ListInterestingPeopleByUserId()
        {
            return await UserInterestService.ListInterestingPeopleByUserId(User.Claims.First(c => c.Type == "UserID").Value);
        }
    }
}
