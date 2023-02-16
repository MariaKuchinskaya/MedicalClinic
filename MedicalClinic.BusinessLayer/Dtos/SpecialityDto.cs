namespace MedicalClinic.BusinessLayer.Entities
{
    public class SpecialityDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }    

        public List<DoctorDto> Doctors { get; set; }
    }
}
