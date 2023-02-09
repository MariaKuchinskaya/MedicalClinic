using MedicalClinic.DAL.Entities;

namespace EfWebTutorial.Services.Interfaces
{
    public interface IDoctorService
    {
        public Task <Doctor> CreateNewDoctor(Doctor doctor);

        public Task<List<Doctor>> GetAllDoctors();

        public Task DeleteAsync(int id);
        public Task <Doctor> EditAsync(Doctor doctor);

        public Task<Doctor> GetDoctorByIdAsync(int id);



    }
}
