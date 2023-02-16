namespace MedicalClinic.Domain.Entities
{
    public class Appointment
    {
        public int Id { get; set; } 
        public DateTime TimeStamp { get; set; }    
        public string Results { get; set; } 
        public int? DoctorId { get; set; }  
        public virtual Doctor Doctor { get; set; }  
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }    

    }
}
