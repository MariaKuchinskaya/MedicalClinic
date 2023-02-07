using MedicalClinic.Common.Enums;

namespace MedicalClinic.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string PasswordHash { get; set; }    
        public string Email { get; set; }   

        public UserType UserType { get; set; }  
    }
}
