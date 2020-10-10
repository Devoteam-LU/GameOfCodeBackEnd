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
    public class BorrowerProjectController : ControllerBase
    {
        public BorrowerProjectController(BorrowerProjectService borrowerProjectService)
        {
            BorrowerProjectService = borrowerProjectService;
        }

        private BorrowerProjectService BorrowerProjectService { get; }
    }
}
