namespace MedicalClinic.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; } 
        public string PhoneNumber { get; set; } 
        public string Email { get; set; }
        public int? UserId { get; set; }    
        public virtual User User { get; set; }
        public int? SpecialityId { get; set; }
        public virtual Speciality Speciality { get; set; }
        public virtual List <Appointment> Appointments { get; set; }    

    }
}
