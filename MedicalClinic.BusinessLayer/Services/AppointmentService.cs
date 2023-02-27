using AutoMapper;
using EfWebTutorial.Repositories;
using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;
using MedicalClinic.Services.Interfaces;

namespace MedicalClinic.BusinessLayer.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(AppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> CreateNewAppointmentAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            var result =  await _appointmentRepository.CreateAsync(appointment);

            return _mapper.Map<AppointmentDto>(result);
        }

        public async Task<List<AppointmentDto>> GetAllAppointmentsAsync()
        {
            var result = await _appointmentRepository.GetAllItemsAsync();

            return _mapper.Map<List<AppointmentDto>>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _appointmentRepository.DeleteAsync(id);
        }


        public async Task<AppointmentDto> EditAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);

            var result =  await _appointmentRepository.EditAsync(appointment);

            return _mapper.Map<AppointmentDto>(result);
        }


        public async Task<AppointmentDto> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetItemAsync(id);

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<List<AppointmentDto>> GetAppointmentHistoryByPatientIdAsync(int patientId)
        {
            var result = await _appointmentRepository.GetAppointmentHistoryByPatientIdAsync(patientId);
            
            return _mapper.Map<List<AppointmentDto>>(result);
        }
    }
}
