using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IDoctorService
    {
        public Task <DoctorDto> CreateNewDoctor(DoctorDto doctor);

        public Task<List<DoctorDto>> GetAllDoctors();

        public Task DeleteAsync(int id);

        public Task <DoctorDto> EditAsync(DoctorDto doctor);

        public Task<DoctorDto> GetDoctorByIdAsync(int id);



    }
}
