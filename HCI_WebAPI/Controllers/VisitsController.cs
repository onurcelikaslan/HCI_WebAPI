using HCI_WebAPI.Models;
using HCI_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HCI_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        public IVisitService visitService { get; }
        public VisitsController(IVisitService visitService)
        {
            this.visitService = visitService;
        }

        [HttpGet("isAlive")]
        public IActionResult IsAlive()
        {
            var dateNow = DateTime.UtcNow.ToString();

            return Ok(dateNow);
        }

        [HttpPost("addvisit")]
        public async Task<IActionResult> AddVisit(Visit visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await this.visitService.AddVisit(visit);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetVisits(Guid patientId, Guid hospitalId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<Visit>? result;
            if (hospitalId.Equals(Guid.Empty) && patientId.Equals(Guid.Empty))
            {
                result = await visitService.GetAllVisit();
            }
            else
            {
                result = await visitService.GetVisitsByPatientIdAndHospitalId(patientId, hospitalId);
            }
            return Ok(result);
        }
    }
}
