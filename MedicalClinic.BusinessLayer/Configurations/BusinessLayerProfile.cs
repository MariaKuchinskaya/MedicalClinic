using AutoMapper;
using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Dtos.Csv;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;

namespace MedicalClinic.BusinessLayer.Configurations
{
    public class BusinessLayerProfile: Profile
    {
        public BusinessLayerProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Speciality, SpecialityDto>().ReverseMap();
            CreateMap<Analyze, AnalyzeDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<AnalyzeResult, AnalyzeResultDto>().ReverseMap();

           CreateMap<Appointment, AppDtoCsv>()
               .ForMember(
               dest => dest.DoctorName,
               opt => opt.MapFrom(src => src.Doctor.Name)
           )

               .ForMember(
               dest => dest.PatientName,
               opt => opt.MapFrom(src => src.Patient.Name)
           )

               .ForMember(
               dest => dest.Results,
               opt => opt.MapFrom(src => src.Results)
           )

               .ForMember(
               dest => dest.Results,
               opt => opt.MapFrom(src => src.TimeStamp)
           );
        }
    }
}
