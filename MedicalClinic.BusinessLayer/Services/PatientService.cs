using AutoMapper;ftfyyggyyu
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.DAL.Repositories;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public class PatientService : IPatientService
    {
        PatientRepository _patientRepository;
        IMapper _mapper;

        public PatientService(PatientRepository patientRepository, IMapper mapper)
        {
            patientRepository = _patientRepository;
            _mapper = mapper;
        }

        public async Task<PatientDto> CreateNewPatient(PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            var savedPacient = await _patientRepository.CreateAsync(patient);

            return _mapper.Map<PatientDto>(savedPacient);
        }

        public async Task<List<PatientDto>> GetAllPatients()
        {
            var res = await _patientRepository.GetAllItemsAsync();
            return res;
        }

        public async Task DeleteAsync(int id)
        {
            await _patientRepository.DeleteAsync(id);

        }


        public async Task<Patient> EditAsync(Patient patient)
        {
            return await _patientRepository.EditAsync(patient);
        }


        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _patientRepository.GetItemAsync(id);
            return patient;
        }
    }
}
