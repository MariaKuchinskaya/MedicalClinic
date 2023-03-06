using AutoMapper;
using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Factories;
using MedicalClinic.BusinessLayer.Helpers.ReportGenerator.Interfaces;
using MedicalClinic.Common.Enums;
using MedicalClinic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

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

        //[HttpGet("GetPatientHistoryInCsvFormat")]
        //public async Task<IActionResult> GetPatientHistoryInCsvFormat(int patientId)
        //{
        //    var result = await _appointmentService.GetAppointmentHistoryByPatientIdCsvAsync(patientId);

        //    var csvString = Helpers.CsvHelper.GenerateCsvFromObjectList(result);

        //    var stream = Helpers.CsvHelper.GenerateStreamFromString(csvString);

        //    return File(stream, "application/octet-stream", "result.csv");

        //}

        [HttpGet("GetPatientHistoryInFormat")]
        public async Task<IActionResult> GetPatientHistoryInFormat(int patientId, ExportType type = ExportType.Csv)
        {
            var result = await _appointmentService.GetAppointmentHistoryByPatientIdCsvAsync(patientId);
            ExportDataGeneratorFactory? factory = null;

            switch (type)
            {
                case ExportType.Csv:
                    factory = new CsvGeneratorFactory();
                    break;
                case ExportType.Pdf:
                    factory = new PdfGeneratorFactory();
                    break;
            }

            if (factory != null)
            {
                ITranslator translator = factory.CreateGenerator();
                var stream = await translator.GetReport(result);


                return File(stream, "application/octet-stream", $"result.{type.ToString().ToLower()}");
            }

            throw new Exception();
        }
    }
}