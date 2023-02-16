using AutoMapper;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.DAL.Repositories;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public class PatientService : IPatientService
    {
        private readonly PatientRepository _patientRepository;
        private readonly IMapper _mapper;

        public PatientService(PatientRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto> CreateNewPatientAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var savedPacient = await _patientRepository.CreateAsync(patient);

            return _mapper.Map<PatientDto>(savedPacient);
        }

        public async Task<List<PatientDto>> GetAllPatientsAsync()
        {
            var result = await _patientRepository.GetAllItemsAsync();
            return _mapper.Map<List<PatientDto>>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);
        }


        public async Task<PatientDto> EditAsync(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var result = await _patientRepository.EditAsync(patient);

            return _mapper.Map<PatientDto>(result);
        }


        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetItemAsync(id);

            return _mapper.Map<PatientDto>(patient);
        }
    }
}
