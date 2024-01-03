using HCI_WebAPI.Models;
using HCI_WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HCI_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalsController:ControllerBase
    {
        public IHospitalService hospitalService { get; set; }
        public HospitalsController(IHospitalService hospitalService)
        {
            this.hospitalService = hospitalService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await this.hospitalService.GetHospitals();
            return Ok(result);
        }

        [HttpPost("addhospital")]
        public async Task<IActionResult> AddHospital(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await this.hospitalService.AddHospital(hospital);
            return Ok(result);
        }
    }
}
