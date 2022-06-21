using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.DTOs.Branch;
using MIS.Application.Interfaces.Services;
using MIS.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;        
        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchInfoDTO>>> GetBranches()
        {
            return Ok(await _branchService.GetAllEntitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BranchInfoDTO>> GetBranch(int id)
        {   
            return Ok(await _branchService.GetEntityInfoAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<BranchInfoDTO>> PostBranch([FromBody] BranchDTO branch)
        {
            return Ok(await _branchService.AddEntityAsync(branch));            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BranchInfoDTO>> PutBranch(int id, [FromBody] BranchDTO branch)
        {
            return Ok(await _branchService.UpdateEntityAsync(id, branch));
        }
    }
}
