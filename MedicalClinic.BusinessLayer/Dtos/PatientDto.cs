using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.Domain.Entities;
using System.Numerics;

namespace MedicalClinic.BusinessLayer.Entities
{
    public class PatientDto
    {
        public PatientDto(Patient patient)
        {
            this.Email = patient.Email;
            this.Surname = patient.Surname;
            this.User = new UserDto(patient.User);
            this.PhoneNumber = patient.PhoneNumber;
            this.Name = patient.Name;
            this.Appointments = new List<AppointmentDto>();
            foreach (var appointment in patient.Appointments)
            {
                this.Appointments.Add(new AppointmentDto(appointment));
            }
        }
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Surname { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }  
        public UserDto User { get; set; }
        public List <AppointmentDto> Appointments { get; set; }    
    }
}
