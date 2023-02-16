using MedicalClinic.BusinessLayer.Dtos;

namespace MedicalClinic.BusinessLayer.Entities
{
    public class PatientDto
    {
        public string Name { get; set; }    

        public string Surname { get; set; } 

        public string PhoneNumber { get; set; } 

        public string Email { get; set; }  

        public List<AppointmentDto> Appointments { get; set; }    
    }
}
