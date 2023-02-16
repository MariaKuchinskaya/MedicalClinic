using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.BusinessLayer.Entities
{
    public class DoctorDto
    {
        public DoctorDto(Doctor doctor)
        { 
            this.Email = doctor.Email;  
            this.Name = doctor.Name;    
            this.User = new UserDto(doctor.User); 
            this.Id = doctor.Id;    
            this.PhoneNumber = doctor.PhoneNumber;
            this.Speciality = new SpecialityDto (doctor.Speciality);
            this.Appointments = new List<AppointmentDto>();
            foreach (var appointment in doctor.Appointments)
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
        public SpecialityDto Speciality { get; set; }
        public List <AppointmentDto> Appointments { get; set; }    

    }
}
