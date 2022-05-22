using BookKeeping.DataAccess.Entitties;
using BookKeeping.DataAccess.Repository;
using BookKeeping.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BookKeeping.WebApi.Controllers
{
    [Route("Reconciliation")]
    public class ReconciliationController : Controller
    {
        private readonly IReconciliationRepository _reconciliationRepository;
        public ReconciliationController(IReconciliationRepository reconciliation)
        {
            _reconciliationRepository = reconciliation;
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] List<Reconciliation> model)
        {
            try
            {
                var result = await _reconciliationRepository.Save(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
           
        }
        
        [AllowAnonymous]
        [HttpGet("GetInitializeReconciliationData")]
        public async Task<IActionResult> GetInitializeReconciliationData(int year)
        {
            var result = await _reconciliationRepository.InitializeReconciliationData(year);
           
            return Ok(result);

        }

    }
}
