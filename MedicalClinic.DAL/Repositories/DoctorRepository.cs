using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using MedicalClinic.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace EfWebTutorial.Repositories
{
    public class DoctorRepository : IBaseRepository<Doctor>
    {
        private readonly ApplicationContext _db;

        public DoctorRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Doctor item)
        {
            _db.Doctors.AddAsync(item);
            _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id != null)
            {
                var doctor = await _db.Doctors.FirstOrDefaultAsync(p => p.Id == id);
                if (doctor != null)
                {
                    _db.Doctors.Remove(doctor);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<List<Doctor>> GetAllItemsAsync()
        {
            var res1 = await _db.Doctors.ToListAsync();
            return res1;    
            

        }

        public async Task<List<Doctor>> GetAllItemsSortedAsync()
        {
            var res1 = await _db.Doctors.ToListAsync();
            var res = await _db.Doctors
                      .OrderBy(x => x.Name)
                      .ToListAsync();
            return res;

           


        }
        
        public async Task<Doctor> GetOneItemAsync(int id)
        {
            var res = await _db.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        public async Task EditAsync(Doctor doctor)
        {
            var dbDoctor = await _db.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);  
            if (dbDoctor != null)
            {
                dbDoctor.Name = doctor.Name;  
                dbDoctor.Surname = doctor.Surname;
                dbDoctor.Speciality = dbDoctor.Speciality;
            }
           
            _db.SaveChanges();
        }


    }
}
