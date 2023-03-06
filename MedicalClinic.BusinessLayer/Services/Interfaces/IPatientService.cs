using MedicalClinic.BusinessLayer.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IPatientService
    {
        public Task <PatientDto> CreateNewPatientAsync(PatientDto patient);

        public Task<List<PatientDto>> GetAllPatientsAsync();

        public Task DeleteAsync(int id);

        public Task <PatientDto> EditAsync(PatientDto patient);

        public Task<PatientDto> GetPatientByIdAsync(int id);
    }
}
