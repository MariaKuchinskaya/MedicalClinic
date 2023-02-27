using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.Services.Interfaces
{
    public interface IAppointmentService
    {
        public Task <AppointmentDto> CreateNewAppointmentAsync(AppointmentDto appointment);

        public Task<List<AppointmentDto>> GetAllAppointmentsAsync();

        public Task DeleteAsync(int id);

        public Task <AppointmentDto> EditAsync(AppointmentDto patient);

        public Task<AppointmentDto> GetAppointmentByIdAsync(int id);

        public Task<List<AppointmentDto>> GetAppointmentHistoryByPatientIdAsync (int patientId);    
    }
}
