using HCI_WebAPI.Models;
using HCI_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HCI_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        public IPatientService patientService { get; set; }

        public PatientsController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpPost("addpatient")]
        public async Task<IActionResult> AddPatient(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await this.patientService.AddPatient(patient);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.patientService.GetPatients();
            return Ok(result);
        }
    }
}
