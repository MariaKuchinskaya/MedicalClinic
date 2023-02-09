
using MedicalClinic.DAL.Entities;
using MedicalClinic.Models;

namespace EfWebTutorial.Services.Interfaces
{
    public interface IPatientService
    {
        public Task <Patient> CreateNewPatient(Patient patient);

        public Task<List<Patient>> GetAllPatients();

        public Task DeleteAsync(int id);
        public Task <Patient> EditAsync(Patient patient);

        public Task<Patient> GetPatientByIdAsync(int id);


    }
}
