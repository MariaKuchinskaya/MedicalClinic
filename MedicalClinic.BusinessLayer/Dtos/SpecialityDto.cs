using MedicalClinic.Domain.Entities;

namespace MedicalClinic.BusinessLayer.Entities
{
    public class SpecialityDto
    {

        public SpecialityDto(Speciality speciality)
        {
            this.Id = speciality.Id;    
            this.Name = speciality.Name;    
            this.Doctors = new List<DoctorDto>();
            foreach (var doctors in speciality.Doctors)
            {
                this.Doctors.Add(new DoctorDto(doctors));
            }
        }



        public int Id { get; set; } 
        public string Name { get; set; }    

        public List<DoctorDto> Doctors { get; set; }
    }
}
