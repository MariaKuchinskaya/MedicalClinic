using EfWebTutorial.Services.Interfaces;
using MedicalClinic.Models;
using Microsoft.AspNetCore.Mvc;


namespace EfWebTutorial.Controlles
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;    
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var patient = await _patientService.GetAllPatients();
            return View(patient);
        }
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            _patientService.CreateNewPatient(patient);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

