using AutoMapper;
using MedicalClinic.BusinessLayer.Dtos;
using MedicalClinic.BusinessLayer.Entities;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
