
using EfWebTutorial.Repositories;
using EfWebTutorial.Services.Interfaces;
using MedicalClinic.DAL.Entities;
using MedicalClinic.Models;

namespace EfWebTutorial.Services
{
    public class PatientService : IPatientService
    {
        PatientRepository _patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            patientRepository = _patientRepository;
        }

        public async Task<Patient> CreateNewPatient(Patient doctor)
        {
            return await _patientRepository.CreateAsync(doctor);

        }

        public async Task<List<Patient>> GetAllPatients()
        {
            var res = await _patientRepository.GetAllItemsAsync();
            return res;
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);

        }


        public async Task<Patient> EditAsync(Patient patient)
        {
            return await _patientRepository.EditAsync(patient);
        }


        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetItemAsync(id);
            return patient;
        }
    }
}
