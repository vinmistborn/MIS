using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MIS.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.API.Controllers
{
    public class TotalCashFlowController : BaseController
    {
        private readonly ICashFlowService _cashFlowService;

        public TotalCashFlowController(ICashFlowService cashFlowService)
        {
            _cashFlowService = cashFlowService;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyCashFlow()
        {
            var dailyCashFlow = await _cashFlowService.GetDailyCashFlowAsync();
            return Ok(dailyCashFlow);
        }

        [HttpGet("monthly")]
        public async Task<IActionResult> GetMonthlyCashFlow()
        {
            var monthlyCashFlow = await _cashFlowService.GetMonthlyCashFlowAsync();
            return Ok(monthlyCashFlow);
        }
        
        [HttpGet("yearly")]
        public async Task<IActionResult> GetYearlyCashFlow()
        {
            var yearlyCashFlow = await _cashFlowService.GetYearlyCashFlowAsync();
            return Ok(yearlyCashFlow);
        }
    }
}
