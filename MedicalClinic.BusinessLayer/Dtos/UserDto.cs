using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Common.Enums;

namespace MedicalClinic.Domain.Entities
{
    public class UserDto
    {
        public UserDto(User user) 
        { 
            this.Id = user.Id;  
            this.UserType = user.UserType;    
            this.Email = user.Email;    
            this.PasswordHash = user.PasswordHash;
        }    
        public int Id { get; set; } 
        public string PasswordHash { get; set; }    
        public string Email { get; set; }   

        public UserType UserType { get; set; }  

        public List <PatientDto> Patients { get; set; }
        public List<DoctorDto> Doctors { get; set; }


    }
}
