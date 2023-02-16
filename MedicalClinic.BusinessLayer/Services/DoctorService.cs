using AutoMapper;
using EfWebTutorial.Repositories;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Services.Interfaces;

namespace MedicalClinic.BusinessLayer.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(DoctorRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public async Task<DoctorDto> CreateNewDoctorAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            var result =  await _doctorRepository.CreateAsync(doctor);

            return _mapper.Map<DoctorDto>(result);
        }

        public async Task<List<DoctorDto>> GetAllDoctorsAsync()
        {
            var result = await _doctorRepository.GetAllItemsAsync();

            return _mapper.Map<List<DoctorDto>>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _doctorRepository.DeleteAsync(id);
        }


        public async Task<DoctorDto> EditAsync(DoctorDto doctorDto)
        {
            var doctor = _mapper.Map<Doctor>(doctorDto);

            var result =  await _doctorRepository.EditAsync(doctor);

            return _mapper.Map<DoctorDto>(result);
        }


        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var doctor = await _doctorRepository.GetItemAsync(id);

            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
