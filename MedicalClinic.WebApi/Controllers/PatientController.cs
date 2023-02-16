using AutoMapper;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MedicalClinic.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService, IMapper mapper)
        {
            _logger = logger;
            _patientService = patientService; 
        }

        [HttpGet(Name = "Patient")]
        [ProducesResponseType(typeof(List<PatientDto>), 200)]
        [ProducesResponseType(typeof(string), 500)]

        public async Task<IEnumerable<PatientDto>> Get()
        {
            try
            {
                var result = await _patientService.GetAllPatientsAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}