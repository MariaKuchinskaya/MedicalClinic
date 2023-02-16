using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.BusinessLayer.Dtos
{
    public class AppointmentDto
    {
        public AppointmentDto(Appointment appointment)
        {
            this.Patient = new PatientDto(appointment.Patient);
            this.TimeStamp = appointment.TimeStamp;
            this.Results = appointment.Results;
            this.Doctor = new DoctorDto(appointment.Doctor); 

        }
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Results { get; set; }
        public DoctorDto Doctor { get; set; }
        public PatientDto Patient { get; set; }

    }
}
