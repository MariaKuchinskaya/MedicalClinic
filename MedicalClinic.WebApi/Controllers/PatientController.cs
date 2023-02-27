using AutoMapper;
using MedicalClinic.BusinessLayer.Dtos;
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
        private readonly IAppointmentService _appointmentService;

        public PatientController(ILogger<PatientController> logger, IPatientService patientService, IMapper mapper, IAppointmentService appointmentService)
        {
            _logger = logger;
            _patientService = patientService;
            _appointmentService = appointmentService;   
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

        public async Task<IEnumerable<AppointmentDto>> GetPatientHistory(int patientId)
        {
            try
            {
                var result = await _appointmentService.GetAppointmentHistoryByPatientIdAsync(patientId);
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