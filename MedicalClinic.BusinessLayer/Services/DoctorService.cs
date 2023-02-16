using EfWebTutorial.Repositories;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Services.Interfaces;

namespace MedicalClinic.BusinessLayer.Services
{
    public class DoctorService : IDoctorService
    {
        DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            doctorRepository = _doctorRepository;
        }

        public async Task<DoctorDto> CreateNewDoctor(DoctorDto doctor)
        {
            return await _doctorRepository.CreateAsync(doctor);

        }

        public async Task<List<DoctorDto>> GetAllDoctors()
        {
            var res = await _doctorRepository.GetAllItemsAsync();
            return res;
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);

        }


        public async Task<DoctorDto> EditAsync(DoctorDto doctor)
        {
            return await _doctorRepository.EditAsync(doctor);
        }


        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetItemAsync(id);
            return doctor;
        }
    }
}
