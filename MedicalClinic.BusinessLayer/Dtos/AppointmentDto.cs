using MedicalClinic.BusinessLayer.Entities;

namespace MedicalClinic.BusinessLayer.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Results { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }

    }
}
