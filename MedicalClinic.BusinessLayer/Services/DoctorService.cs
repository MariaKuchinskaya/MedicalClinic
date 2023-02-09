

using EfWebTutorial.Repositories;
using EfWebTutorial.Services.Interfaces;
using MedicalClinic.DAL.Entities;

namespace EfWebTutorial.Services
{
    public class DoctorService : IDoctorService
    {
        DoctorRepository _doctorRepository; 

        public DoctorService(DoctorRepository doctorRepository)
        {
            doctorRepository = _doctorRepository;
        }

        public async Task <Doctor> CreateNewDoctor(Doctor doctor)
        {
            return await _doctorRepository.CreateAsync(doctor);

        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            var res = await _doctorRepository.GetAllItemsAsync();
            return res;
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
           
        }


        public async Task<Doctor> EditAsync(Doctor doctor)
        {
            return await _doctorRepository.EditAsync(doctor);
        }

   
        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetItemAsync(id);
            return doctor;
        }
    }
}
