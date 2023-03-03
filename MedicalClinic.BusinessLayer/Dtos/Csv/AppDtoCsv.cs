using MedicalClinic.BusinessLayer.Entities;

namespace MedicalClinic.BusinessLayer.Dtos.Csv
{
    public class AppDtoCsv
    {
        public DateTime TimeStamp { get; set; }
        public string Results { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
    }
}
