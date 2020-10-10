using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
