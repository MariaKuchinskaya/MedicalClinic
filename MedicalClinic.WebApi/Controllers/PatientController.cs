using Aspose.Cells;
using AutoMapper;
using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Dtos.Csv;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SkiaSharp;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using MedicalClinic.WebApi.Helpers;
using static System.Net.Mime.MediaTypeNames;

namespace MedicalClinic.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientService _patientService;
        private readonly IAppointmentService _appointmentService;
        private readonly IMapper _mapper;


        //public AppDtoCsv dto; 

        public PatientController(ILogger<PatientController> logger, IPatientService patientService,
            IAppointmentService appointmentService, IMapper mapper)
        {
            _logger = logger;
            _patientService = patientService;
            _appointmentService = appointmentService;
            _mapper = mapper;
        }

        [HttpGet("Patient")]
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

        [HttpGet("GetPatientHistory")]
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

        [HttpGet("GetPatientHistoryInCsvFormat")]
        public async Task<IActionResult> GetPatientHistoryInCsvFormat(int patientId)
        {
            var result = await _appointmentService.GetAppointmentHistoryByPatientIdCsvAsync(patientId);

            var csvString = CsvHelper.GenerateCsvFromObjectList(result);

            var stream = CsvHelper.GenerateStreamFromString(csvString);

            return File(stream, "application/octet-stream", "result.csv");

        }
    }
}