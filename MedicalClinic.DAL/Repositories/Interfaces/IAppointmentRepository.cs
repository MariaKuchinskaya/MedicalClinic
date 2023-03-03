using EfWebTutorial.Interfaces;
using MedicalClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalClinic.DAL.Repositories.Interfaces
{
    public interface IAppointmentRepository: IRepository<Appointment>
    {
        Task<List<Appointment>> GetAppointmentHistoryByPatientIdAsync(int patientId);
    
    }
}
