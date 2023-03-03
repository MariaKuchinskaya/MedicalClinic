using MedicalClinic.DAL.Repositories.Interfaces;
using MedicalClinic.DAL;
using MedicalClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationContext _db;

        public AppointmentRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<Appointment> CreateAsync(Appointment item)
        {
            _db.Appointments.Add(item);
            _db.SaveChanges();
            return item;
        }

        public async Task DeleteAsync(int id)
        {
            var appointment = await _db.Appointments.FirstOrDefaultAsync(p => p.Id == id);
            if (appointment != null)
            {
                _db.Appointments.Remove(appointment);
                await _db.SaveChangesAsync();
            }
        }



        public async Task<List<Appointment>> GetAllItemsAsync()
        {
            return await _db.Appointments.ToListAsync();
        }


        public async Task<Appointment> GetItemAsync(int id)
        {
            return await _db.Appointments.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<Appointment> EditAsync(Appointment appointment)
        {
            var dbAppointment = await _db.Appointments.FirstOrDefaultAsync(x => x.Id == appointment.Id);
            if (dbAppointment != null)
            {
                dbAppointment.PatientId = appointment.PatientId;
                dbAppointment.Results = appointment.Results;
                dbAppointment.TimeStamp = appointment.TimeStamp;
                dbAppointment.DoctorId = appointment.DoctorId;  
                _db.SaveChanges();
            }
            return dbAppointment;
        }

        public async Task<List<Appointment>> GetAppointmentHistoryByPatientIdAsync(int patientId)
        {
            var history = await _db.Appointments.Where(x => x.PatientId == patientId && x.TimeStamp <= DateTime.Now)
                .Include(x => x.Doctor)
                .Include(x => x.Patient)
                .ToListAsync();

            return history;
        }
    }
}

