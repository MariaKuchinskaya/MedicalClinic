using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.BusinessLayer.Entities
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }  
        public UserDto User { get; set; }
        public SpecialityDto Speciality { get; set; }
        //public List <AppointmentDto> Appointments { get; set; }    

    }
}
