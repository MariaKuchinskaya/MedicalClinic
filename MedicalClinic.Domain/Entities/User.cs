using MedicalClinic.Common.Enums;

namespace MedicalClinic.Domain.Entities
{
    public class User
    {
        public int Id { get; set; } 
        public string PasswordHash { get; set; }    
        public string Email { get; set; }   

        public UserType UserType { get; set; }  

        public virtual List <Patient> Patients { get; set; }
        public virtual List<Doctor> Doctors { get; set; }


    }
}
