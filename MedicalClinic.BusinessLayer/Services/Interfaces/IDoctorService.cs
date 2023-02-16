using MedicalClinic.BusinessLayer.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IDoctorService
    {
        public Task <DoctorDto> CreateNewDoctorAsync(DoctorDto doctor);

        public Task<List<DoctorDto>> GetAllDoctorsAsync();

        public Task DeleteAsync(int id);

        public Task <DoctorDto> EditAsync(DoctorDto doctor);

        public Task<DoctorDto> GetDoctorByIdAsync(int id);
    }
}
