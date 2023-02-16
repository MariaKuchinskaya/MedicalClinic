using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IPatientService
    {
        public Task <PatientDto> CreateNewPatient(PatientDto patient);

        public Task<List<PatientDto>> GetAllPatients();

        public Task DeleteAsync(int id);

        public Task <PatientDto> EditAsync(PatientDto patient);

        public Task<PatientDto> GetPatientByIdAsync(int id);
    }
}
