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
        private readonly PatientService _patientService;
        private readonly IMapper _mapper;

        

        public PatientController(ILogger<PatientController> logger, PatientService patientService, IMapper mapper)
        {
            _logger = logger;
            _patientService = patientService;
            _mapper = mapper;   
        }

        [HttpGet(Name = "Patient")]
        public async Task<IEnumerable<PatientDto>> Get()
        {
            var result = await _patientService.GetAllPatients();
            return result; 
        }
    }
}