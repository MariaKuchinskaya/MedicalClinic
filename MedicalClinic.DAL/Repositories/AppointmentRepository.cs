using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using MedicalClinic.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Repositories
{
    public class AppointmentRepository : IBaseRepository<Appointment>
    {
        private readonly ApplicationContext _db;

        public AppointmentRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Appointment item)
        {
            _db.Appointments.Add(item);
            _db.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int id)
        {
                var appointment = await _db.Appointments.FirstOrDefaultAsync(p => p.Id == id);
                if (appointment != null)
                {
                    _db.Appointments.Remove(appointment); ;
                    await _db.SaveChangesAsync();
                    return true;
                }

            return false;
        }

        public async Task EditAsync(Appointment item)
        {

            _db.Appointments.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Appointment>> GetAllItemsAsync()
        {
            var res = await _db.Appointments.ToListAsync();
            return res;
        }

        public Task<List<Appointment>> GetAllItemsSortedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Appointment> GetOneItemAsync(int id)
        {
            var res = await _db.Appointments.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
    }
}

