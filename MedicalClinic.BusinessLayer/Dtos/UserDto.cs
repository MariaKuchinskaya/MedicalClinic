using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Common.Enums;

namespace MedicalClinic.Domain.Entities
{
    public class UserDto
    { 
        public int Id { get; set; } 
        public string PasswordHash { get; set; }    
        public string Email { get; set; }   

        public UserType UserType { get; set; }  

        public List <PatientDto> Patients { get; set; }
        public List<DoctorDto> Doctors { get; set; }
    }
}
